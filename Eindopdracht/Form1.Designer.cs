namespace Eindopdracht
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
            this.btn_start = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_Header = new System.Windows.Forms.Label();
            this.txt_Subheader = new System.Windows.Forms.Label();
            this.txt_Subheader2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.White;
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(27, 707);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(337, 55);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Get started";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Eindopdracht.Properties.Resources.start_unscreen;
            this.pictureBox1.Location = new System.Drawing.Point(67, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 365);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txt_Header
            // 
            this.txt_Header.AutoSize = true;
            this.txt_Header.BackColor = System.Drawing.Color.Transparent;
            this.txt_Header.ForeColor = System.Drawing.Color.White;
            this.txt_Header.Location = new System.Drawing.Point(12, 490);
            this.txt_Header.Name = "txt_Header";
            this.txt_Header.Size = new System.Drawing.Size(187, 20);
            this.txt_Header.TabIndex = 2;
            this.txt_Header.Text = "Follow the latest shoe style";
            // 
            // txt_Subheader
            // 
            this.txt_Subheader.AutoSize = true;
            this.txt_Subheader.BackColor = System.Drawing.Color.Transparent;
            this.txt_Subheader.ForeColor = System.Drawing.Color.White;
            this.txt_Subheader.Location = new System.Drawing.Point(67, 557);
            this.txt_Subheader.Name = "txt_Subheader";
            this.txt_Subheader.Size = new System.Drawing.Size(235, 20);
            this.txt_Subheader.TabIndex = 3;
            this.txt_Subheader.Text = "Find the best shoes for comfort in \r\n";
            this.txt_Subheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Subheader2
            // 
            this.txt_Subheader2.AutoSize = true;
            this.txt_Subheader2.BackColor = System.Drawing.Color.Transparent;
            this.txt_Subheader2.ForeColor = System.Drawing.Color.White;
            this.txt_Subheader2.Location = new System.Drawing.Point(107, 592);
            this.txt_Subheader2.Name = "txt_Subheader2";
            this.txt_Subheader2.Size = new System.Drawing.Size(136, 20);
            this.txt_Subheader2.TabIndex = 4;
            this.txt_Subheader2.Text = "your daily activities";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 845);
            this.Controls.Add(this.txt_Subheader2);
            this.Controls.Add(this.txt_Subheader);
            this.Controls.Add(this.txt_Header);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_start);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_start;
        private PictureBox pictureBox1;
        private Label txt_Header;
        private Label txt_Subheader;
        private Label txt_Subheader2;
    }
}