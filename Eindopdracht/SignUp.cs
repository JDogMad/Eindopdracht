using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Eindopdracht {
    public partial class SignUp : Form {
        int Id;
        // Connectiestring van de datbase 
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thele\\Documents\\.NET\\Eindopdracht\\Eindopdracht\\Shop.mdf;Integrated Security=True";

        public SignUp() {
            InitializeComponent();
        }

        // Font en grootte van de header aanpassen
        private void SignUp_Load(object sender, EventArgs e) {
            txt_header.Font = new Font("Arial", 16, FontStyle.Bold);
        }

        // Shortcuts voor uw button
        // Zegt gewoon dat als je enter drukt dat het als button functioneert.
        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e) {
            List<int> ids = new();
            SqlConnection connection = new(connectionString);
            connection.Open();

            // Men mag alleen verder gaan mocht er geen textbox leeg zijn
            if (txt_confirmation.Text != string.Empty || txt_password.Text != string.Empty || txt_username.Text != string.Empty) {
                if(txt_password.Text.Length > 7)   {
                    // Als de password en de password checker hetzelfde zijn dan pas mag deze aangemaakt worden
                    if (txt_password.Text == txt_confirmation.Text)
                    {
                        SqlCommand cmd = new("SELECT Id FROM [User]", connection);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            ids.Add((int)read["Id"]);
                        }
                        read.Close();

                        Id += ids.Count + 1;

                        SqlCommand command = new("SELECT Id, Username, Password FROM [User] WHERE username='" + txt_username.Text + "'", connection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read()) {
                            reader.Close();
                            MessageBox.Show("Username already taken. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } else {
                            reader.Close();
                            command = new("INSERT INTO [User] (Id, Username, Password) VALUES ('"
                                    + Id + "','" + txt_username.Text + "','" + txt_password.Text + "') ", connection);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Succefully done. Please login with your credentials. ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LogIn login = new();

                            this.Hide();
                            login.ShowDialog();
                            this.Close();
                        }
                    }  else {
                        // Mogelijke error opgevangen door Messagebox
                        MessageBox.Show("Passwords are not the same. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    // Mogelijke error opgevangen door Messagebox
                    MessageBox.Show("Password is not long engough! Please make sure that your password has at least 8 characters.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                // Mogelijke error opgevangen door Messagebox
                MessageBox.Show("Not all fields are filled. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // Mocht men al een account hebben dan kan je op de link drukken 
        // deze zal u naar de login page brengen
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            LogIn login = new LogIn();

            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
