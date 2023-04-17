namespace AukcioClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelvissza = new System.Windows.Forms.Label();
            this.LBLvisszajelzes = new System.Windows.Forms.Label();
            this.LBLtoken = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnList = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBidAmount = new System.Windows.Forms.TextBox();
            this.btnBid = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDeleteID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(933, 32);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Belép";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(933, 61);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Kilép";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(721, 33);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 23);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(827, 33);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(721, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Felhasználónév";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(827, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Jelszó";
            // 
            // labelvissza
            // 
            this.labelvissza.AutoSize = true;
            this.labelvissza.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelvissza.Location = new System.Drawing.Point(719, 113);
            this.labelvissza.Name = "labelvissza";
            this.labelvissza.Size = new System.Drawing.Size(217, 30);
            this.labelvissza.TabIndex = 6;
            this.labelvissza.Text = "Szerver visszajelzése:";
            // 
            // LBLvisszajelzes
            // 
            this.LBLvisszajelzes.AutoSize = true;
            this.LBLvisszajelzes.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LBLvisszajelzes.ForeColor = System.Drawing.Color.Red;
            this.LBLvisszajelzes.Location = new System.Drawing.Point(719, 143);
            this.LBLvisszajelzes.Name = "LBLvisszajelzes";
            this.LBLvisszajelzes.Size = new System.Drawing.Size(108, 30);
            this.LBLvisszajelzes.TabIndex = 7;
            this.LBLvisszajelzes.Text = "...................";
            // 
            // LBLtoken
            // 
            this.LBLtoken.AutoSize = true;
            this.LBLtoken.Location = new System.Drawing.Point(721, 87);
            this.LBLtoken.Name = "LBLtoken";
            this.LBLtoken.Size = new System.Drawing.Size(64, 15);
            this.LBLtoken.TabIndex = 8;
            this.LBLtoken.Text = "...................";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(721, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Token:";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvProducts.Location = new System.Drawing.Point(38, 33);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.Size = new System.Drawing.Size(660, 454);
            this.dgvProducts.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Termék név";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Kezdő licit";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Jelenlegi ár";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tulajdonos";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Nyerő licitelő";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnList.Location = new System.Drawing.Point(516, 507);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(182, 44);
            this.btnList.TabIndex = 11;
            this.btnList.Text = "Listázás";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddProduct.Location = new System.Drawing.Point(933, 190);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(106, 81);
            this.btnAddProduct.TabIndex = 12;
            this.btnAddProduct.Text = "Termék felvétel";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(742, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Termék név:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(818, 204);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(100, 23);
            this.txtProductName.TabIndex = 14;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(818, 233);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(100, 23);
            this.txtProductPrice.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Kezdő licit ár:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(767, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Licit ár:";
            // 
            // txtBidAmount
            // 
            this.txtBidAmount.Location = new System.Drawing.Point(818, 340);
            this.txtBidAmount.Name = "txtBidAmount";
            this.txtBidAmount.Size = new System.Drawing.Size(100, 23);
            this.txtBidAmount.TabIndex = 23;
            // 
            // btnBid
            // 
            this.btnBid.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBid.Location = new System.Drawing.Point(933, 295);
            this.btnBid.Name = "btnBid";
            this.btnBid.Size = new System.Drawing.Size(106, 81);
            this.btnBid.TabIndex = 22;
            this.btnBid.Text = "Licit";
            this.btnBid.UseVisualStyleBackColor = true;
            this.btnBid.Click += new System.EventHandler(this.btnBid_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(750, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "Termék ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(818, 311);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 23);
            this.txtID.TabIndex = 25;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(933, 406);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 81);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Törlés";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(750, 444);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Termék ID:";
            // 
            // txtDeleteID
            // 
            this.txtDeleteID.Location = new System.Drawing.Point(818, 441);
            this.txtDeleteID.Name = "txtDeleteID";
            this.txtDeleteID.Size = new System.Drawing.Size(100, 23);
            this.txtDeleteID.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(38, 515);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 30);
            this.label4.TabIndex = 31;
            this.label4.Text = "Termék neve:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(183, 512);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(132, 35);
            this.txtSearch.TabIndex = 30;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Location = new System.Drawing.Point(321, 512);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 35);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Keresés";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(1014, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 18);
            this.label10.TabIndex = 33;
            this.label10.Text = "Idő kijelentkezésig:";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimer.Location = new System.Drawing.Point(1041, 55);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(35, 32);
            this.lblTimer.TabIndex = 34;
            this.lblTimer.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 687);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDeleteID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBidAmount);
            this.Controls.Add(this.btnBid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LBLtoken);
            this.Controls.Add(this.LBLvisszajelzes);
            this.Controls.Add(this.labelvissza);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Name = "Form1";
            this.Text = "Aukciós applikáció";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelvissza;
        private System.Windows.Forms.Label LBLvisszajelzes;
        private System.Windows.Forms.Label LBLtoken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBidAmount;
        private System.Windows.Forms.Button btnBid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDeleteID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
