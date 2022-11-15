using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using Label = System.Windows.Forms.Label;

namespace Eindopdracht {
    public partial class LogIn : Form {
        // Connectiestring van de database
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Shop.mdf;Integrated Security=True";

        public LogIn() {
            InitializeComponent();
        }

        // Shortcuts voor uw button
        // Zegt gewoon dat als je enter drukt dat het als button functioneert.
        private void Form1_KeyDown(object sender, KeyEventArgs e)  {
            if (e.KeyCode == Keys.Enter)  {
                btnLogin.PerformClick();
            }
        }

        // Deze code is allemaal om in te loggen
        private void BtnLogin_Click(object sender, EventArgs e) {
            SqlConnection connection = new(connectionString);
            connection.Open();

            // Voor dat men gaat checken of een user bestaat 
            // Checken we eerst dat alle velden ingevuld zijn
            if (txt_password.Text != string.Empty || txt_username.Text != string.Empty)  {
                SqlCommand command = new("SELECT Id, Username, Password FROM [User] WHERE Username='" + txt_username.Text + "' AND Password='" + txt_password.Text + "'", connection);
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read()) {
                    reader.Close();
                    SqlCommand cmd = new("UPDATE [User] SET LoggedIn= '" + "true" + "' WHERE Username='" + txt_username.Text + "' ", connection);
                    cmd.ExecuteNonQuery();

                    User.Username = txt_username.Text;

                    Profile profile = new();
                    this.Hide();
                    profile.ShowDialog();
                    this.Close();
                }
                else {
                    // Mogelijke error opgevangen door Messagebox
                    reader.Close();
                    MessageBox.Show("The combination does not exist. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                // Mogelijke error opgevangen door event
                // Eigen event implementatie 
                MyEvent error = new();
                error.foutOpvangen += Error_message;
                error.FoutHandlerMethode();
            }

            connection.Close();
        }

        // Error message voor de event
        public static void Error_message() {
            MessageBox.Show("Please fill all fields in. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Een link naar de signup pagina mocht je nog geen account hebben
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            SignUp signup = new();

            this.Hide();
            signup.ShowDialog();
            this.Close();
        }
    }
}
