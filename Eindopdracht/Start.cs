namespace Eindopdracht {
    public partial class Start : Form {
        ShoeDAO shoeDAO;

        public Start() {
            InitializeComponent();
        }

        // Hier word de methode die alles toont opgroepen
        private void Start_Load(object sender, EventArgs e) {
            // Hier zal hij de dao oproepen 
            // en daarnaa de methode getAlleSchoenen oproepen
            shoeDAO = new ShoeDAO();
            shoeDAO.getAllShoes(this);
            
        }

        // Code die redirect naar de juiste pagina
        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e) {
                Checkout checkout = new Checkout();

                this.Hide();
                checkout.ShowDialog();
                this.Close();
            
        }

        // Code die redirect naar de juiste pagina
        private void profileToolStripMenuItem_Click(object sender, EventArgs e)  {
            // Hier gaat hij wel checken of je al ingelogd bent 
            // ZO ja dan zal je uw bods zien 
            // anders word je naar de signup pagina gedirect
            if (User.Username != String.Empty) {
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
    }
}
