using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace AukcioServer
{
    public class BiddingAppImpl : BiddingApp.BiddingAppBase
    {
        readonly string connectionString = "server=localhost;user id=root;password=;database=aukciodb;";
        static readonly Dictionary<string, string> loggedInUsers = new Dictionary<string, string>();
        static readonly Dictionary<string, DateTime> loggedInUsersExpiration = new Dictionary<string, DateTime>();
        private static readonly Timer expirationTimer = new Timer(5000);

        // Az idõzítõ csak egyszer indul el az osztály elsõ betöltésekor
        static BiddingAppImpl()
        {
            expirationTimer.Elapsed += ExpirationTimer_Elapsed;
            expirationTimer.Start();
        }

        private static void ExpirationTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (loggedInUsersExpiration)
            {
                var expiredTokens = loggedInUsersExpiration.Where(kvp => kvp.Value < DateTime.Now).ToList();
                foreach (var expiredToken in expiredTokens)
                {
                    loggedInUsersExpiration.Remove(expiredToken.Key);
                    lock (loggedInUsers)
                    {
                        loggedInUsers.Remove(expiredToken.Key);
                    }
                }
            }
        }

        public override Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM users WHERE user_username = @username AND user_password = @password", connection);
                command.Parameters.AddWithValue("@username", request.Username);
                command.Parameters.AddWithValue("@password", request.Password);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var token = Guid.NewGuid().ToString();

                    lock (loggedInUsers)
                    {
                        loggedInUsers.Add(token, request.Username);
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Jelenleg bejelentkezett felhasználók:");
                    foreach (KeyValuePair<string, string> kvp in loggedInUsers)
                    {
                        Console.WriteLine("Token: " + kvp.Key + ", Username: " + kvp.Value);
                    }

                    int time = 30000;
                    var expiration = DateTime.Now.AddMilliseconds(time);
                    lock (loggedInUsersExpiration)
                    {
                        loggedInUsersExpiration.Add(token, expiration);
                    }

                    var convertedExpiration = Timestamp.FromDateTime(expiration.ToUniversalTime());

                    return Task.FromResult(new LoginResponse
                    {
                        Success = true,
                        Message = "Sikeres bejelentkezés.",
                        Token = token,
                        TokenExpiration = convertedExpiration,
                        LogoutTimeRemaining = time,
                    });
                }
                else
                {
                    return Task.FromResult(new LoginResponse
                    {
                        Success = false,
                        Message = "Rossz felhasználónév vagy jelszó."
                    });
                }
                
            }
        }


        public override Task<LogoutResponse> Logout(LogoutRequest request, ServerCallContext context)
        {
            lock(loggedInUsers) 
            {
                loggedInUsers.Remove(request.Token);
            }
            lock (loggedInUsersExpiration)
            {
                loggedInUsersExpiration.Remove(request.Token);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Jelenleg bejelentkezett felhasználók:");
            foreach (KeyValuePair<string, string> kvp in loggedInUsers)
            {
                Console.WriteLine("Token: " + kvp.Key + ", Username: " + kvp.Value);
            }

            if (!loggedInUsersExpiration.ContainsKey(request.Token) || loggedInUsersExpiration[request.Token] < DateTime.Now)
            {
                return Task.FromResult(new LogoutResponse
                {
                    Success = true,
                    Message = "Sikeres kijelentkezés."
                });
            }
            else
            {
                return Task.FromResult(new LogoutResponse
                {
                    Success = false,
                    Message = "Nem sikerült kijelentkezni."
                });
            }
        }

        public override Task<ListResponse> List(ListRequest request, ServerCallContext context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Jelenleg bejelentkezett felhasználók:");
            foreach (KeyValuePair<string, string> kvp in loggedInUsers)
            {
                Console.WriteLine("Token: " + kvp.Key + ", Username: " + kvp.Value);
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM aukcio", connection);
                var reader = command.ExecuteReader();
                var response = new ListResponse();

                while (reader.Read())
                {
                    response.Products.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        ProductPrice = reader.GetInt32(2),
                        HighestBid = reader.GetInt32(3),
                        ProductOwner= reader.GetString(4),
                        WinnerUser = reader.GetString(5),
                    });
                    
                }
                return Task.FromResult(response);


            }
        }

        public override Task<AddProductResponse> AddProduct(AddProductRequest request, ServerCallContext context)
        {
            if (!loggedInUsers.ContainsKey(request.Token))
            {
                return Task.FromResult(new AddProductResponse
                {
                    LoggedIn = false,
                    Message = "Jelentkezz be!"
                });
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Jelenleg bejelentkezett felhasználók:");
            foreach (KeyValuePair<string, string> kvp in loggedInUsers)
            {
                Console.WriteLine("Token: " + kvp.Key + ", Username: " + kvp.Value);
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO aukcio (termek_nev, termek_ar, termek_licit, tulaj) VALUES (@name, @price, @bid, @owner)", connection);
                command.Parameters.AddWithValue("@name", request.ProductName);
                command.Parameters.AddWithValue("@price", request.ProductPrice);
                command.Parameters.AddWithValue("@bid", request.ProductPrice);
                command.Parameters.AddWithValue("@owner", request.ProductOwner);
                command.ExecuteNonQuery();
                return Task.FromResult(new AddProductResponse
                {
                    Success = true,
                    Message = "Termék sikeresen felvéve."
                });
            }
        }

        public override Task<BidResponse> Bid(BidRequest request, ServerCallContext context)
        {
            if (!loggedInUsers.ContainsKey(request.Token))
            {
                return Task.FromResult(new BidResponse
                {
                    LoggedIn = false,
                    Message = "Jelentkezz be!"
                });
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Jelenleg bejelentkezett felhasználók:");
            foreach (KeyValuePair<string, string> kvp in loggedInUsers)
            {
                Console.WriteLine("Token: " + kvp.Key + ", Username: " + kvp.Value);
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE aukcio SET termek_licit = @bid, jelenlegi_nyertes = @winner WHERE id = @id AND termek_licit < @bid", connection);
                command.Parameters.AddWithValue("@bid", request.BidPrice);
                command.Parameters.AddWithValue("@id", request.ProductId);
                command.Parameters.AddWithValue("@winner", request.WinnerUser);

                var rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    return Task.FromResult(new BidResponse
                    {
                        Success = false,
                        Message = "Alacsony árat adtál meg."
                    });
                }
                else
                {
                    return Task.FromResult(new BidResponse
                    {
                        Success = true,
                        Message = "Licit elfogadva."
                    });
                }
            }
        }

        public override Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            if (!loggedInUsers.ContainsKey(request.Token))
            {
                return Task.FromResult(new DeleteProductResponse
                {
                    LoggedIn = false,
                    Message = "Jelentkezz be!"
                });
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Jelenleg bejelentkezett felhasználók:");
            foreach (KeyValuePair<string, string> kvp in loggedInUsers)
            {
                Console.WriteLine("Token: " + kvp.Key + ", Username: " + kvp.Value);
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM aukcio WHERE id=@id AND tulaj=@username", connection);
                command.Parameters.AddWithValue("@id", request.Id);
                command.Parameters.AddWithValue("@username", loggedInUsers[request.Token]);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command = new MySqlCommand("DELETE FROM aukcio WHERE id=@id", connection);
                    command.Parameters.AddWithValue("@id", request.Id);
                    command.ExecuteNonQuery();
                    return Task.FromResult(new DeleteProductResponse
                    {
                        Success = true,
                        Message = "Törlésre került a termék."
                    });
                }
                else
                {
                    return Task.FromResult(new DeleteProductResponse
                    {
                        Success = false,
                        Message = "Csak a saját termékedet törölheted le."
                    });
                }
            }
        }

        public override Task<SearchResponse> Search(SearchRequest request, ServerCallContext context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Jelenleg bejelentkezett felhasználók:");
            foreach (KeyValuePair<string, string> kvp in loggedInUsers)
            {
                Console.WriteLine("Token: " + kvp.Key + ", Username: " + kvp.Value);
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM aukcio WHERE termek_nev LIKE @productName", connection);
                command.Parameters.AddWithValue("@productName", "%" + request.ProductName + "%");
                var reader = command.ExecuteReader();
                var response = new SearchResponse();
                while (reader.Read())
                {
                    response.Products.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        ProductPrice = reader.GetInt32(2),
                        HighestBid = reader.GetInt32(3),
                        ProductOwner = reader.GetString(4),
                        WinnerUser= reader.GetString(5),
                    });
                }
                return Task.FromResult(response);
            }
        }

}


 }
