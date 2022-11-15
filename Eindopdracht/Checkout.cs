
using System.Data.SqlClient;


namespace Eindopdracht {
    public partial class Checkout : Form {
        // Connectiestring
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Shop.mdf;Integrated Security=True";

        public Checkout() {
            InitializeComponent();
        }

        // Code die redirect naar de nodige pagina
        private void btn_home_Click(object sender, EventArgs e) {
            Start startpage = new Start();

            this.Hide();
            startpage.ShowDialog();
            this.Close();
        }

        // Code die redirect naar de nodige pagina 
        private void btn_profiel_Click(object sender, EventArgs e) {
            // Hier gaat hij wel checken of je al ingelogd bent 
            // ZO ja dan zal je uw bods zien 
            // anders word je naar de signup pagina gedirect
            if (User.Username != String.Empty)  {
                Profile profile = new();

                this.Hide();
                profile.ShowDialog();
                this.Close();
            }  else {
                SignUp signup = new();

                this.Hide();
                signup.ShowDialog();
                this.Close();
            }
        }

        // Hier haalt hij de schoenen waarop je een bod hebt geplaatst op 
        private void Checkout_Load(object sender, EventArgs e) {
            int y = 0;
            int userId = 0;
            decimal balance = 0;
            List<Bid> listOfBids = new();
            List<Shoe> listOfShoes = new();

            SqlConnection connection = new(connectionString);
            connection.Open();

            if (User.Username != null) {

                SqlCommand cmd = new("SELECT Id, Balance FROM [User] WHERE Username='" + User.Username + "'", connection);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        userId = (int)reader["Id"];
                        balance = (decimal)reader["Balance"];
                    }
                }

                if (userId != 0) {
                    SqlCommand command = new("SELECT Id, ShoeId, Bid FROM Bid WHERE UserId='" + userId + "'", connection);
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            listOfBids.Add(new Bid() {
                                Id = (int)reader["Id"],
                                ShoeId = (int)reader["ShoeId"],
                                BidOnShoe = (decimal)reader["Bid"]
                            });
                        }
                        reader.Close();
                    }

                    // Een basic LINQ Query om zaken uit de lijst te halen
                    var bids = from bid in listOfBids select bid;
                    foreach (var bid in bids) {
                        SqlCommand cnd = new("SELECT Id, Name, Price FROM Shoe WHERE Id='" + bid.ShoeId + "'", connection);
                        SqlDataReader reader = cnd.ExecuteReader();
                        reader.Read();
                        listOfShoes.Add(new Shoe()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Price = (decimal)reader["Price"]
                        });
                        reader.Close();

                        // Een loop door mijn lijst van schoenen om de namen, prijzen etc op te halen 
                        foreach (Shoe shoe in listOfShoes.ToList()) {
                            // Ik creer een nieuwe panel, met alle nodig labels, buttons etc..
                            Panel bid_details = new() {
                                Name = "My bids"
                            };

                            Label shoe_name = new() {
                                Text = shoe.Name,
                                Size = new(200, 50),
                                Top = 20,
                                Left = 10
                            };

                            Label shoe_price = new() {
                                Text = shoe.Price.ToString(),
                                Size = new(150, 50),
                                Left = 210,
                                Top = 20
                            };

                            Label my_bid = new() {
                                Text = "My bid: ",
                                Size = new(100, 25),
                                Left = 10,
                                Top = 70
                            };

                            Label shoe_bid = new() {
                                Text = "€" + bid.BidOnShoe.ToString("0.00##"),
                                Size = new(150, 50),
                                Left = 110,
                                Top = 70
                            };


                            Button buy_shoe = new() {
                                Text = "Buy now",
                                Size = new(150, 50),
                                Left = 10,
                                Top = 120,
                            };
                            
                            buy_shoe.Click += btn_buyShoe;

                            bid_details.Location = new Point(10, y * 70);
                            bid_details.Size = new Size(300, 350);
                            bid_details.Controls.Add(shoe_name);
                            bid_details.Controls.Add(shoe_price);
                            bid_details.Controls.Add(my_bid);
                            bid_details.Controls.Add(shoe_bid);
                            bid_details.Controls.Add(buy_shoe);
                            this.Controls.Add(bid_details);

                            y += 5;

                            void btn_buyShoe(object o, EventArgs sender) {
                                MsbBod msb_checkout = new() {
                                    Width = 414,
                                    Height = 517,
                                    Text = "Checkout"
                                };

                                Label lbl_priceToPay = new() {
                                    Text = "Total: ",
                                    Size = new(120, 50),
                                    Left = 10,
                                    Top = 70
                                };

                                Label priceToPay = new() {
                                    Text = "€" + bid.BidOnShoe.ToString("0.00##"),
                                    Size = new(150, 50),
                                    Left = 160,
                                    Top = 70
                                };

                                Label lbl_acc_balance = new(){
                                    Text = "Balance: ",
                                    Size = new(120, 50),
                                    Left = 10,
                                    Top = 120
                                };

                                Label acc_balance = new() {
                                    Text = "€" + balance.ToString("0.00##"),
                                    Size = new(150, 50),
                                    Left = 160,
                                    Top = 120
                                };

                                Button btn_ok = new(){
                                    Text = "OK",
                                    Size = new(150, 50),
                                    Left = 10,
                                    Top = 170
                                };
                                // Lambda expressie 
                                btn_ok.Click += (o, sender) => {
                                    msb_checkout.Close();
                                };


                                balance -= bid.BidOnShoe;

                                if (balance < 0) {
                                    balance += bid.BidOnShoe;
                                    MessageBox.Show("Your balance is not suffiecent. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }  else {
                                    SqlCommand pay = new("UPDATE [User] SET Balance = '" + balance.ToString("0####") + "' WHERE Username = '" + User.Username + "' ", connection);
                                    pay.ExecuteNonQuery();
                                    MessageBox.Show("Thank you for shopping at Laced! ", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    SqlCommand deleteShoe = new("DELETE FROM Wishlist WHERE ShoeId='" + shoe.Id + "'", connection);
                                    deleteShoe.ExecuteNonQuery();

                                    SqlCommand deleteBid = new("DELETE FROM Bid WHERE ShoeId='" + shoe.Id + "' AND UserId='" + userId + "'", connection);
                                    deleteBid.ExecuteNonQuery();

                                    try {
                                        SqlCommand deleteStock = new("DELETE FROM Shoe WHERE Id='" + shoe.Id + "'", connection);
                                        deleteStock.ExecuteNonQuery();
                                    }  catch {
                                        MessageBox.Show("The order went thru!. ", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }

                                }

                                msb_checkout.Controls.Add(lbl_priceToPay);
                                msb_checkout.Controls.Add(priceToPay);
                                msb_checkout.Controls.Add(lbl_acc_balance);
                                msb_checkout.Controls.Add(acc_balance);
                                msb_checkout.Controls.Add(btn_ok);
                                msb_checkout.ShowDialog();
                            }
                            listOfShoes.RemoveAt(0);
                        }
                    }                    
                }
            } else {
                // Dit is een mogelijke errror
                // Deze word dan opgevangen door een Messagebox een redirect naar de login pagina
                MessageBox.Show("You are not logged in. To place an order you need to be logged in. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogIn login = new();

                this.Hide();
                login.ShowDialog();
                this.Close();
            }
        }
    }

}
    

