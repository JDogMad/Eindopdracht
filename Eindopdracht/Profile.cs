using System.Data.SqlClient;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace Eindopdracht {
    public partial class Profile : Form {
        // Uw connectie met de database
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Shop.mdf;Integrated Security=True";

        private int Id;
        private int y;
        private int userId;
        List<int> Ids = new();
        List<int> IdsOfShoes = new();
        List<Shoe> shoes = new();


        public Profile() {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)  {
            // Mocht er toevallig bij het loaden van de profile pagina iemand toch niet ingelogd zijn dan zal 
            // deze weer geredirect worden naar de login pagina
            if (User.Username != null) {
                lbl_username.Text = (string)User.Username;
                lbl_username.Font = new Font("Franklin Gothic Book", 15, FontStyle.Regular);
                lbl_hi.Font = new Font("Franklin Gothic Book", 18, FontStyle.Regular);
                this.Show();
            } else {
                LogIn login = new();

                this.Hide();
                login.ShowDialog();
                this.Close();
            }

            // Dit is code geschreven zodat ik de achtergrond kleur kan veranderen 
            // van die lelijke grijs naar een wat deftige kleur
            foreach (Control control in this.Controls) {
                MdiClient client = control as MdiClient;
                if (!(client == null)) {
                    client.BackColor = Color.White;
                    break;
                }
            }
        }

        // Dit is een button waar je jouw balance mee kan zien 
        // Ik heb dit dubbel gemaakt omdat deze veel mooier is dan die mdi child form 
        private void btn_seeBalance_Click(object sender, EventArgs e)  {
            decimal balance = 0;
            // De connectie met de database openen 
            SqlConnection connectie = new(connectionString);
            connectie.Open();
            // De balance van de user ophalen 
            SqlCommand cmd = new("SELECT Balance FROM [User] WHERE Username='" + User.Username + "'", connectie);
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read())
                {
                    balance += (decimal)reader["Balance"];
                }
            }

            MsbBod msb_balance = new() {
                Width = 414,
                Height = 218,
                Text = "Current balance"
            };

            Label lbl_header = new() {
                Size = new(150, 25),
                Text = "My current balance: ",
                Top = 20,
                Left = 10
            };

            Label lbl_balance = new() {
                Size = new(150, 25),
                // De balance van de user tot 2 cijfers na te komma converteren
                Text = "€ " + balance.ToString("0.00##"),
                Top = 20,
                Left = 160
            };

            Button btn_ok = new() {
                Text = "OK",
                Left = 180,
                Top = 70,
                Size = new(100, 25)
            };
            // Lambda expressie 
            btn_ok.Click += (sender, e) => {
                msb_balance.Close();
            };

            msb_balance.Controls.Add(lbl_header);
            msb_balance.Controls.Add(lbl_balance);
            msb_balance.Controls.Add(btn_ok);
            msb_balance.ShowDialog();

        }

        private void btn_AddBalance_Click(object sender, EventArgs e){
            decimal balance = 0;
            // De connectie met de database openen 
            SqlConnection connectie = new(connectionString);
            connectie.Open();
            // De balance van de user ophalen 
            SqlCommand cmd = new("SELECT Balance FROM [User] WHERE Username='" + User.Username + "'", connectie);
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read())
                {
                    balance += (decimal)reader["Balance"];
                }
            }

            MsbBod msb_balance = new();
            msb_balance.Width = 414;
            msb_balance.Height = 328;
            msb_balance.Text = "Add balance";

            Label label = new();
            label.Left = 50;
            label.Top = 20;
            label.Text = "How much do you want to add? ";

            // Hier neem ik een numericupdown omdat het algemeen gebruik hiervoor getallen zijn 
            NumericUpDown input_bid = new();
            input_bid.Left = 50;
            input_bid.Top = 50;
            input_bid.Width = 200;
            input_bid.Maximum = 99999999999;

            Button confirmation = new();
            confirmation.Text = "PAY";
            confirmation.Left = 150;
            confirmation.Top = 150;
            confirmation.Size = new(120, 50);
            // Lambda expressie 
            confirmation.Click += (sender, e) => {
                decimal addbalance = (decimal)input_bid.Value;
                balance += addbalance;
                balance.ToString("0####");

                // De balance van de user updaten nadat de user op oke geeft gedrukt 
                SqlCommand command = new("UPDATE [User] SET Balance='" + balance.ToString("0####") + "' WHERE Username='" + User.Username + "'", connectie);
                command.ExecuteNonQuery();
                MessageBox.Show("Balance updated. ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Het venster sluiten 
                msb_balance.Close();
            };

            Button cancel = new();
            cancel.Text = "Cancel";
            cancel.Left = 10;
            cancel.Top = 150;
            cancel.Size = new(120, 50);
            // Lambda expressie 
            cancel.Click += (sender, e) => {
                msb_balance.Close();
            };

            msb_balance.Controls.Add(label);
            msb_balance.Controls.Add(input_bid);
            msb_balance.Controls.Add(confirmation);
            msb_balance.Controls.Add(cancel);
            msb_balance.ShowDialog();

            // connectie met de database sluiten
            connectie.Close();
        }

        private void btn_seeWishlist_Click(object sender, EventArgs e) {
            // Uw connectie met de database openen 
            SqlConnection connection = new(connectionString);
            connection.Open();
            // De Id van de user ophalen 
            SqlCommand us = new("SELECT Id FROM [User] WHERE Username='" + User.Username + "'", connection);
            SqlDataReader readr = us.ExecuteReader();
            while (readr.Read()) {
                userId = (int)readr["Id"];
            }
            readr.Close();

            // De schoenId van de user ophalen 
            SqlCommand cmd = new SqlCommand("SELECT ShoeId FROM Wishlist WHERE UserId='" + userId + "'", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())  {
                IdsOfShoes.Add((int)reader["ShoeId"]);
            }
            reader.Close();

            // Als men nog een shoen in de wishlist heeft opgeslaan 
            // Dan zal de shoeId gelijk blijven aan 0 
            // Dus ik check of deze gelijk is aan 0 -> ja? Dan zal er een messagebox komen en zeggen dat de wishlist leeg is
            // -> neen? Dan zal het gewoon de inhoud van de wishlist tonen 
            if (IdsOfShoes.Count == 0) {
                MessageBox.Show("Your wishlist is empty! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                foreach (int id in IdsOfShoes)    {
                    SqlCommand md = new("SELECT Name, Price FROM Shoe WHERE Id='" + id + "'", connection);
                    SqlDataReader r = md.ExecuteReader();
                    while (r.Read()) {
                        shoes.Add(new Shoe()  {
                            Name = (string)r["Name"],
                            Price = (decimal)r["Price"]
                        });
                    }
                    r.Close();
                }

                foreach (Shoe s in shoes) {
                    Panel wishlist_details = new();
                    wishlist_details.Name = "Shoe" + s;
                    wishlist_details.BackColor = Color.White;

                    // Hier maak ik een label aan voor de schoen naam 
                    Label shoe_name = new();
                    shoe_name.Text = s.Name;
                    shoe_name.Size = new Size(200, 50);
                    shoe_name.Top = 10;

                    // Hier maak ik een label aan voor de schoen prijs 
                    Label shoe_price = new();
                    shoe_price.Text = "€" + s.Price.ToString("0.##");
                    shoe_price.Size = new Size(50, 50);
                    shoe_price.Left = 210;
                    shoe_price.Top = 10;

                    wishlist_details.Location = new Point(10, 350 + y);
                    wishlist_details.Size = new Size(250, 150);
                    wishlist_details.Controls.Add(shoe_name);
                    wishlist_details.Controls.Add(shoe_price);
                    this.Controls.Add(wishlist_details);

                    y += 150;
                }
            }

            // Connectie met de database sluiten 
            connection.Close();
        }

        private void btn_AddWishlist_Click(object sender, EventArgs e)  {
            SqlConnection connection = new(connectionString);
            connection.Open();

            int shoeId = 0;

            MsbBod msb_wishllist = new();
            msb_wishllist.Width = 414;
            msb_wishllist.Height = 328;
            msb_wishllist.Text = "Add a shoe to your wishlist";

            Label label = new();
            label.Left = 10;
            label.Top = 20;
            label.Size = new(150, 25);
            label.Text = "Shoe name: ";

            TextBox txt_name = new();
            txt_name.Left = 160;
            txt_name.Top = 20;
            txt_name.Size = new(150, 25);

            Button confirmation = new();
            confirmation.Text = "ADD";
            confirmation.Left = 150;
            confirmation.Top = 150;
            confirmation.Size = new(120, 25);
            confirmation.Click += (sender, e) =>  {
                msb_wishllist.Close();
            };

            msb_wishllist.Controls.Add(label);
            msb_wishllist.Controls.Add(txt_name);
            msb_wishllist.Controls.Add(confirmation);
            msb_wishllist.ShowDialog();


            SqlCommand cmdd = new("SELECT Id FROM Shoe WHERE Name='" + txt_name.Text + "'", connection);
            SqlDataReader reader = cmdd.ExecuteReader();
            reader.Read();
            shoeId = (int)reader["Id"];
            reader.Close();


            if (confirmation.Text == "ADD")  {
                SqlCommand us = new("SELECT Id FROM [User] WHERE Username='" + User.Username + "'", connection);
                SqlDataReader readr = us.ExecuteReader();
                readr.Read();
                userId = (int)readr["Id"];
                readr.Close();

                SqlCommand cd = new("SELECT Id FROM Wishlist", connection);
                SqlDataReader read = cd.ExecuteReader();
                while (read.Read())
                {
                    Ids.Add((int)read["Id"]);
                }
                read.Close();

                Id += Ids.Count + 1;


                SqlCommand cmd = new("INSERT INTO Wishlist (Id, ShoeId, UserId) VALUES ('" + Id + "','" + shoeId + "','" + userId + "')", connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Shoe added to your wishlist", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();
        }

        private void btn_Logout_Click(object sender, EventArgs e){
            // Uw connectie met de database openen 
            SqlConnection connection = new(connectionString);
            connection.Open();
            // Ik update de database door te zeggen dat loggedIn false is 
            SqlCommand cmd = new("UPDATE [User] SET LoggedIn= '" + "false" + "' WHERE Username='" + User.Username + "' ", connection);
            cmd.ExecuteNonQuery();
            // Daarna laat ik de login form opnieuw tonen 
            // Maar bij de onload staat dat als loggedIn gelijk is aan false dat ze u redirecten naar log in
            LogIn login = new();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void Profile_Resize(object sender, ScrollEventArgs e) {
            this.Invalidate();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) {
            Start startpage = new Start();

            this.Hide();
            startpage.ShowDialog();
            this.Close();
        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e) {
            Checkout checkout = new Checkout();

            this.Hide();
            checkout.ShowDialog();
            this.Close();
        }

        // Ik heb hier een mdi child form gemaakt 
        // hierin kan je uw balance bekijken maar dan in een mdi form
        private void btn_somethingRelatedToMDI_Click(object sender, EventArgs e) {
            MsbBod ietsMDI = new();
            this.IsMdiContainer = true;
            ietsMDI.MdiParent = this;
            ietsMDI.Width = 414;
            ietsMDI.Height = 218;
            ietsMDI.Text = "Current balance";

            decimal balance = 0;
            // De connectie met de database openen 
            SqlConnection connectie = new(connectionString);
            connectie.Open();
            // De balance van de user ophalen 
            SqlCommand cmd = new("SELECT Balance FROM [User] WHERE Username='" + User.Username + "'", connectie);
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    balance += (decimal)reader["Balance"];
                }
            }

            Label lbl_header = new();
            lbl_header.Size = new(150, 25);
            lbl_header.Text = "My current balance: ";
            lbl_header.Top = 20;
            lbl_header.Left = 10;

            Label lbl_balance = new();
            lbl_balance.Size = new(150, 25);
            // De balance van de user tot 2 cijfers na te komma converteren
            lbl_balance.Text = "€ " + balance.ToString("0.00##");
            lbl_balance.Top = 20;
            lbl_balance.Left = 160;

            Button btn_ok = new();
            btn_ok.Text = "OK";
            btn_ok.Left = 180;
            btn_ok.Top = 70;
            btn_ok.Size = new(100, 25);
            // Lambda expressie 
            btn_ok.Click += (sender, e) => {
                ietsMDI.Close();
            };

            ietsMDI.Controls.Add(lbl_header);
            ietsMDI.Controls.Add(lbl_balance);
            ietsMDI.Controls.Add(btn_ok);
            ietsMDI.Show();
        }
    }
}
