using Eindopdracht.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Image = System.Drawing.Image;
using TextBox = System.Windows.Forms.TextBox;

namespace Eindopdracht {
    internal class ShoeDAO {
        // De connectiestring, dus de link van uw database 
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Shop.mdf;Integrated Security=True";

        // y is de locatie bepaler 
        int y = 0;
        // Deze initialisatie is voor een generator van ids
        int id = 0;
        int UserId = 0;
        List<int> BidIds = new();
        List<string> alleFotos = new() { "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\triplePink.png", "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\dunklowwhiteblack.png", "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\NewBalance9060.png", "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\GucciXAddidasGazelle.png", "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\Nocta.png", "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\travisScottXNike.png", "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\UnionXJordan2.png", "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\GeorgeTown.png", "C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Resources\\UnionXDunkLow.png" };
        
        // Dit is een methode die alle schoenen vanuit de database gaat ophalen 
        public List<Shoe> getAllShoes(Start start) {
            int i = 0;
            // Een lijst van schoenen waar ik later schoenen in zal opslaan
            List<Shoe> listOfShoes = new();
            // Uw connectie met de database 
            SqlConnection connection = new SqlConnection(connectionString);
            // Uw connectie openenen met de database 
            connection.Open();

            // Hier selecteer ik alles van de tabel Shoe 
            SqlCommand cmd = new SqlCommand("SELECT Id, Name, Description, Price FROM Shoe", connection);
            
            // Hier haal ik eerst alle gegevens van de tabel uit 
            // Daarna sla ik ze op in listOfShoes
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    listOfShoes.Add(new Shoe() {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        Price = (decimal)reader["Price"]
                    });  
                }
            }

            // Dit loopt door de lijst van schoenen 
            // Zodat ik elke schoen en de details kan tonen op de form
            foreach (Shoe shoe in listOfShoes)   {
                // Ik creer een nieuwe panel, met alle nodig labels, buttons etc..
                Panel shoe_details = new() {
                    // Ik voeg elke aangemaakte panel in een lijst 
                    Name = "Shoe" + shoe
                };

                // Hier maak ik een label aan voor de schoen naam 
                Label shoe_name = new(){
                    Text = shoe.Name,
                    Size = new Size(150, 25),
                    BackColor = Color.Transparent,
                    Top = 0,
                    Left = 10
                };

                PictureBox shoe_image = new() {
                    Image = Image.FromFile(alleFotos[i]),
                    Size = new(200, 200),
                    Location = new(10, 70)
                };
                shoe_name.Top = 75;
                shoe_name.Left = 10;

                // Hier maak ik een label aan voor de schoen beschrijving 
                Label shoe_description = new() {
                    Text = shoe.Description,
                    Size = new Size(400, 100),
                    Left = 10,
                    Top = 275
                };

                // Hier maak ik een label aan voor de schoen prijs 
                Label shoe_price = new()  {
                    Text = "€" + shoe.Price.ToString("0.00##"),
                    Size = new Size(100, 25),
                    Left = 10,
                    Top = 375
                };

                //  Hier maak ik een button die zal zorgen voor een bod
                Button btn_bod = new() {
                    Text = "Place a bid",
                    Size = new Size(100, 25),
                    Left = 120,
                    Top = 375,
                    Visible = true
                };
                btn_bod.Click += btn_bod_Click;


                shoe_details.Location = new Point(10, 10 + y);
                shoe_details.Size = new Size(414, 400);
                shoe_details.Controls.Add(shoe_name);
                shoe_details.Controls.Add(shoe_image);
                shoe_details.Controls.Add(shoe_description);
                shoe_details.Controls.Add(shoe_price);
                shoe_details.Controls.Add(btn_bod);
                start.Controls.Add(shoe_details);

                y += 400;
                i ++;

                // Hier maak mijn eigen event 
                // Deze event laat een messagebox tonen waar je een bod kan geven 
                void btn_bod_Click(Object o, EventArgs sender) {
                    // Het aanmaken van een nieuwe form die zal dienen als input
                    MsbBod msb_dialog = new() {
                        Width = 414,
                        Height = 328,
                        Text = "Make an offer"
                    };

                    Label lb_bid = new() {
                        Size = new Size(100, 25),
                        Left = 10,
                        Top = 70,
                        Text = "Bid: "
                    };

                    // Hier neem ik een numericupdown omdat het algemeen gebruik hiervoor getallen zijn 
                    NumericUpDown input_bid = new()  {
                        Left = 70,
                        Top = 100,
                        Width = 200,
                        Maximum = 99999999999
                    };

                    Button confirmation = new() {
                        Text = "PLACE BID",
                        Left = 150,
                        Top = 150,
                        Width = 120
                    };
                    //Lambda expressie
                    confirmation.Click += (sender, e) => {
                        msb_dialog.Close();
                    };

                    msb_dialog.Controls.Add(lb_bid);
                    msb_dialog.Controls.Add(input_bid);
                    msb_dialog.Controls.Add(confirmation);
                    msb_dialog.ShowDialog();

                    if (confirmation.Text == "PLACE BID") {
                        double bid = (double)input_bid.Value;

                        SqlConnection connection = new(connectionString);
                        connection.Open();

                        if (User.Username != null){
                            SqlCommand c = new("SELECT Id FROM [USER] WHERE Username='" + User.Username + "'", connection);
                            SqlDataReader read = c.ExecuteReader();
                            read.Read();
                            UserId = (int)read["Id"];
                            read.Close();

                            SqlCommand cd = new SqlCommand("SELECT Id FROM Bid", connection);
                            SqlDataReader reader = cd.ExecuteReader();
                            while (reader.Read()) {
                                BidIds.Add((int)reader["Id"]);
                            }
                            reader.Close();

                            id += BidIds.Count + 1;

                            SqlCommand cmd = new("INSERT INTO Bid (Id, ShoeId, UserId, Bid) VALUES ('" + id + "','" + shoe.Id + "','" +
                                 UserId + "','" + bid + "')", connection);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Bid placed. ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {
                            // Mogelijke error opgevangen door messagebox
                            MessageBox.Show("You are not logged in. To place a bid, you must be logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                        // Mogelijke error opgevangen door messagebox
                        MessageBox.Show("Bid not placed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // En de connection altijd sluiten erna
            connection.Close();
            return listOfShoes;
        }


    }
}
