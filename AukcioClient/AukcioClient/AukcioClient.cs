using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using AukcioServer;
using AukcioClient;
using Grpc.Core;
using Grpc.Net.Client;

namespace AukcioClient
{
    public partial class Form1 : Form
    {
        private string token="";
        bool loggedIn=false;
        string username = "";
        int remainingTime = 0;
        string loginText = "Jelentkezz be!";

        GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
        BiddingApp.BiddingAppClient client;

        public Form1()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 1000; // 1 mp
            timer1.Tick += timer1_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new BiddingApp.BiddingAppClient(channel);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(!loggedIn)
            {
                var loginResponse = client.Login(new LoginRequest
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                });

                if (loginResponse.Success)
                {
                    token = loginResponse.Token;
                    LBLvisszajelzes.Text = loginResponse.Message;
                    LBLtoken.Text = loginResponse.Token;
                    loggedIn = true;
                    username= txtUsername.Text;
                    remainingTime = loginResponse.LogoutTimeRemaining/1000;
                    timer1.Start();
                }
                else
                {
                    LBLvisszajelzes.Text = loginResponse.Message;
                }
            }
            else
            {
                LBLvisszajelzes.Text = "Már be vagy jelentkezve!";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var logoutResponse = client.Logout(new LogoutRequest
            {
                Token = token
            });

            if (logoutResponse.Success)
            {
                token = "";
                username = "";
                LBLvisszajelzes.Text = logoutResponse.Message;
                LBLtoken.Text = token;
                loggedIn= false;
                timer1.Stop();
                lblTimer.Text = "";
            }
            
        }
        

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var addProductResponse = client.AddProduct(new AddProductRequest
                {
                    Token = token,
                    ProductName = txtProductName.Text,
                    ProductPrice = int.Parse(txtProductPrice.Text),
                    ProductOwner = username,
                });

                if (addProductResponse.Success)
                {
                    LBLvisszajelzes.Text = addProductResponse.Message;
                    txtProductName.Text = "";
                    txtProductPrice.Text = "";
                    btnList.PerformClick();
                }
                else
                {
                    LBLvisszajelzes.Text = addProductResponse.Message;
                }

                if (!addProductResponse.LoggedIn)
                {
                    LBLvisszajelzes.Text = addProductResponse.Message;
                    if(LBLvisszajelzes.Text.Contains(loginText))
                    {
                        LBLtoken.Text = "";
                        loggedIn= false;
                        username = "";
                        timer1.Stop();
                        lblTimer.Text = "";
                    }
                }
            }
            catch (FormatException ex)
            {
                LBLvisszajelzes.Text = "Számot adj meg termék árának!";
            }
        }

        private void btnBid_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedProductId = int.Parse(txtID.Text);
                int bidPrice = int.Parse(txtBidAmount.Text);
                var bidResponse = client.Bid(new BidRequest
                {
                    ProductId = selectedProductId,
                    BidPrice = bidPrice,
                    Token = token,
                    WinnerUser = username,
                });

                if (bidResponse.Success)
                {
                    LBLvisszajelzes.Text = bidResponse.Message;
                    txtID.Text = "";
                    txtBidAmount.Text = "";
                    btnList.PerformClick();
                }
                else
                {
                    LBLvisszajelzes.Text = bidResponse.Message;
                }

                if (!bidResponse.LoggedIn)
                {
                    LBLvisszajelzes.Text = bidResponse.Message;
                    if (LBLvisszajelzes.Text.Contains(loginText))
                    {
                        LBLtoken.Text = "";
                        loggedIn = false;
                        username = "";
                        timer1.Stop();
                        lblTimer.Text = "";
                    }
                }
            }
            catch (FormatException ex)
            {
                LBLvisszajelzes.Text = "Számot adj meg termék árának és Id-nek!";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var deleteResponse = client.DeleteProduct(new DeleteProductRequest
                {
                    Token = token,
                    Id = Convert.ToInt32(txtDeleteID.Text)
                });

                if (deleteResponse.Success)
                {
                    LBLvisszajelzes.Text = deleteResponse.Message;
                    txtDeleteID.Text = "";
                    btnList.PerformClick();
                }
                else
                {
                    LBLvisszajelzes.Text = deleteResponse.Message;
                }

                if (!deleteResponse.LoggedIn)
                {
                    LBLvisszajelzes.Text = deleteResponse.Message;
                    if (LBLvisszajelzes.Text.Contains(loginText))
                    {
                        LBLtoken.Text = "";
                        loggedIn = false;
                        username = "";
                        timer1.Stop();
                        lblTimer.Text = "";
                    }
                }
            }
            catch (FormatException ex)
            {
                LBLvisszajelzes.Text = "Számot adj meg termék Id-nek!";
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {

            var listResponse = client.List(new ListRequest { Token = token });
            dgvProducts.Rows.Clear();
            dgvProducts.Refresh();
            foreach (var product in listResponse.Products)
            {
                dgvProducts.Rows.Add(product.Id, product.ProductName, product.ProductPrice, product.HighestBid, product.ProductOwner, product.WinnerUser);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string productname = txtSearch.Text;
            var searchResponse = client.Search(new SearchRequest {
                ProductName = productname,
                Token = token,
            });

            dgvProducts.Rows.Clear();
            foreach (var product in searchResponse.Products)
            {
                dgvProducts.Rows.Add(product.Id, product.ProductName, product.ProductPrice, product.HighestBid, product.ProductOwner, product.WinnerUser);
            }

            if (!searchResponse.LoggedIn)
            {
                LBLvisszajelzes.Text = searchResponse.Message;
            }
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                lblTimer.Text = remainingTime + " mp";
            }
            else
            {
                LBLtoken.Text = "";
                loggedIn = false;
                username = "";
                timer1.Stop();
                lblTimer.Text = "";
                MessageBox.Show("Munkamenet lejárt. Lépj be újra.", "Lépj be!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
