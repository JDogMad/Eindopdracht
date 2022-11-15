namespace Eindopdracht
{
    partial class Checkout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_home = new System.Windows.Forms.Button();
            this.btn_checkout = new System.Windows.Forms.Button();
            this.btn_profiel = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // btn_home
            // 
            this.btn_home.Image = global::Eindopdracht.Properties.Resources.home__4_;
            this.btn_home.Location = new System.Drawing.Point(22, 797);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(40, 40);
            this.btn_home.TabIndex = 2;
            this.btn_home.UseVisualStyleBackColor = true;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_checkout
            // 
            this.btn_checkout.Image = global::Eindopdracht.Properties.Resources.shopping_cart__1_;
            this.btn_checkout.Location = new System.Drawing.Point(177, 797);
            this.btn_checkout.Name = "btn_checkout";
            this.btn_checkout.Size = new System.Drawing.Size(40, 40);
            this.btn_checkout.TabIndex = 4;
            this.btn_checkout.UseVisualStyleBackColor = true;
            // 
            // btn_profiel
            // 
            this.btn_profiel.Image = global::Eindopdracht.Properties.Resources.user;
            this.btn_profiel.Location = new System.Drawing.Point(331, 797);
            this.btn_profiel.Name = "btn_profiel";
            this.btn_profiel.Size = new System.Drawing.Size(40, 40);
            this.btn_profiel.TabIndex = 5;
            this.btn_profiel.UseVisualStyleBackColor = true;
            this.btn_profiel.Click += new System.EventHandler(this.btn_profiel_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(388, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(10, 849);
            this.vScrollBar1.TabIndex = 6;
            // 
            // Checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(396, 849);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.btn_profiel);
            this.Controls.Add(this.btn_checkout);
            this.Controls.Add(this.btn_home);
            this.Name = "Checkout";
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.Checkout_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_home;
        private Button btn_checkout;
        private Button btn_profiel;
        private VScrollBar vScrollBar1;
    }
}