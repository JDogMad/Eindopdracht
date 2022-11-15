namespace Eindopdracht
{
    partial class Profile
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
            this.btn_seeBalance = new System.Windows.Forms.Button();
            this.lbl_hi = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.btn_AddBalance = new System.Windows.Forms.Button();
            this.btn_seeWishlist = new System.Windows.Forms.Button();
            this.btn_AddWishlist = new System.Windows.Forms.Button();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_somethingRelatedToMDI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_seeBalance
            // 
            this.btn_seeBalance.BackColor = System.Drawing.Color.White;
            this.btn_seeBalance.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_seeBalance.ForeColor = System.Drawing.Color.Black;
            this.btn_seeBalance.Location = new System.Drawing.Point(12, 187);
            this.btn_seeBalance.Name = "btn_seeBalance";
            this.btn_seeBalance.Size = new System.Drawing.Size(161, 29);
            this.btn_seeBalance.TabIndex = 4;
            this.btn_seeBalance.Text = "See balance";
            this.btn_seeBalance.UseVisualStyleBackColor = false;
            this.btn_seeBalance.Click += new System.EventHandler(this.btn_seeBalance_Click);
            // 
            // lbl_hi
            // 
            this.lbl_hi.AutoSize = true;
            this.lbl_hi.BackColor = System.Drawing.Color.White;
            this.lbl_hi.ForeColor = System.Drawing.Color.Black;
            this.lbl_hi.Location = new System.Drawing.Point(12, 62);
            this.lbl_hi.Name = "lbl_hi";
            this.lbl_hi.Size = new System.Drawing.Size(24, 20);
            this.lbl_hi.TabIndex = 5;
            this.lbl_hi.Text = "Hi";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.BackColor = System.Drawing.Color.White;
            this.lbl_username.ForeColor = System.Drawing.Color.Black;
            this.lbl_username.Location = new System.Drawing.Point(12, 88);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(87, 20);
            this.lbl_username.TabIndex = 6;
            this.lbl_username.Text = "Placeholder";
            // 
            // btn_AddBalance
            // 
            this.btn_AddBalance.BackColor = System.Drawing.Color.White;
            this.btn_AddBalance.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_AddBalance.ForeColor = System.Drawing.Color.Black;
            this.btn_AddBalance.Location = new System.Drawing.Point(197, 187);
            this.btn_AddBalance.Name = "btn_AddBalance";
            this.btn_AddBalance.Size = new System.Drawing.Size(167, 29);
            this.btn_AddBalance.TabIndex = 7;
            this.btn_AddBalance.Text = "Add to my balance";
            this.btn_AddBalance.UseVisualStyleBackColor = false;
            this.btn_AddBalance.Click += new System.EventHandler(this.btn_AddBalance_Click);
            // 
            // btn_seeWishlist
            // 
            this.btn_seeWishlist.BackColor = System.Drawing.Color.White;
            this.btn_seeWishlist.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_seeWishlist.ForeColor = System.Drawing.Color.Black;
            this.btn_seeWishlist.Location = new System.Drawing.Point(12, 243);
            this.btn_seeWishlist.Name = "btn_seeWishlist";
            this.btn_seeWishlist.Size = new System.Drawing.Size(161, 29);
            this.btn_seeWishlist.TabIndex = 8;
            this.btn_seeWishlist.Text = "See my wishlist";
            this.btn_seeWishlist.UseVisualStyleBackColor = false;
            this.btn_seeWishlist.Click += new System.EventHandler(this.btn_seeWishlist_Click);
            // 
            // btn_AddWishlist
            // 
            this.btn_AddWishlist.BackColor = System.Drawing.Color.White;
            this.btn_AddWishlist.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_AddWishlist.ForeColor = System.Drawing.Color.Black;
            this.btn_AddWishlist.Location = new System.Drawing.Point(197, 243);
            this.btn_AddWishlist.Name = "btn_AddWishlist";
            this.btn_AddWishlist.Size = new System.Drawing.Size(167, 29);
            this.btn_AddWishlist.TabIndex = 9;
            this.btn_AddWishlist.Text = "Add to my wishlist";
            this.btn_AddWishlist.UseVisualStyleBackColor = false;
            this.btn_AddWishlist.Click += new System.EventHandler(this.btn_AddWishlist_Click);
            // 
            // btn_Logout
            // 
            this.btn_Logout.BackColor = System.Drawing.Color.White;
            this.btn_Logout.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Logout.ForeColor = System.Drawing.Color.Black;
            this.btn_Logout.Location = new System.Drawing.Point(12, 333);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(161, 29);
            this.btn_Logout.TabIndex = 10;
            this.btn_Logout.Text = "Logout";
            this.btn_Logout.UseVisualStyleBackColor = false;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Eindopdracht.Properties.Resources.LacedLogo_removebg_preview__1_;
            this.pictureBox1.Location = new System.Drawing.Point(197, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.checkoutToolStripMenuItem,
            this.profileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(396, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.startToolStripMenuItem.Image = global::Eindopdracht.Properties.Resources.home__4_;
            this.startToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 130, 0);
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // checkoutToolStripMenuItem
            // 
            this.checkoutToolStripMenuItem.Image = global::Eindopdracht.Properties.Resources.shopping_cart;
            this.checkoutToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 150, 0);
            this.checkoutToolStripMenuItem.Name = "checkoutToolStripMenuItem";
            this.checkoutToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            this.checkoutToolStripMenuItem.Click += new System.EventHandler(this.checkoutToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Image = global::Eindopdracht.Properties.Resources.user__1_;
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            // 
            // btn_somethingRelatedToMDI
            // 
            this.btn_somethingRelatedToMDI.BackColor = System.Drawing.Color.White;
            this.btn_somethingRelatedToMDI.Location = new System.Drawing.Point(12, 289);
            this.btn_somethingRelatedToMDI.Name = "btn_somethingRelatedToMDI";
            this.btn_somethingRelatedToMDI.Size = new System.Drawing.Size(352, 29);
            this.btn_somethingRelatedToMDI.TabIndex = 15;
            this.btn_somethingRelatedToMDI.Text = "See balance in MdiChild";
            this.btn_somethingRelatedToMDI.UseVisualStyleBackColor = false;
            this.btn_somethingRelatedToMDI.Click += new System.EventHandler(this.btn_somethingRelatedToMDI_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 849);
            this.Controls.Add(this.btn_somethingRelatedToMDI);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Logout);
            this.Controls.Add(this.btn_AddWishlist);
            this.Controls.Add(this.btn_seeWishlist);
            this.Controls.Add(this.btn_AddBalance);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.lbl_hi);
            this.Controls.Add(this.btn_seeBalance);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Profile_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btn_seeBalance;
        private Label lbl_hi;
        private Label lbl_username;
        private Button btn_AddBalance;
        private Button btn_seeWishlist;
        private Button btn_AddWishlist;
        private Button btn_Logout;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem checkoutToolStripMenuItem;
        private ToolStripMenuItem profileToolStripMenuItem;
        private Button btn_somethingRelatedToMDI;
    }
}