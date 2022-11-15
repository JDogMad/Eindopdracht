using System.Drawing.Drawing2D;

namespace Eindopdracht {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

        }

        // Deze stuk code is compleet overgenomen van het internet 
        // Bron kan u vinden in mijn readMe file 
        // Deze code dient om een gradient te tonen op de eerste form
        protected override void OnPaintBackground(PaintEventArgs e) {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(234, 94, 91),
                                                                       Color.FromArgb(189, 32, 44),
                                                                       90F)) {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        // Code die naar de juiste pagina redirect
        private void btn_start_Click(object sender, EventArgs e) {
            // Het creeren van een nieuwe pagina 
            Start startpage = new Start();

            this.Hide();
            startpage.ShowDialog();
            this.Close(); 
        }

        // Een paar eigenschappen van labels veranderen 
        private void Form1_Load(object sender, EventArgs e) {
            // De titel eigenschappen 
            txt_Header.Font = new Font("Arial", 16, FontStyle.Bold);
            txt_Subheader.Font = new Font("Ariel", 11, FontStyle.Regular);
            txt_Subheader2.Font = new Font("Ariel", 11, FontStyle.Regular);

            // Kleur van de button aanpassen
            btn_start.BackColor = Color.FromArgb(234, 94, 91);
            btn_start.FlatStyle = FlatStyle.Flat;
            btn_start.FlatAppearance.BorderColor = Color.FromArgb(234, 94, 91);
            btn_start.FlatAppearance.BorderSize = 1;

            // Dit is om de gif te laten werken 
            // Wanneer je de app zou opendoen
            pictureBox1.Show();
        }
    }
}