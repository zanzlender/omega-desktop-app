namespace OmegaApp.LogIn
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.KorisnickoImeLabel = new System.Windows.Forms.Label();
            this.KorisnickoImeTextBox = new System.Windows.Forms.TextBox();
            this.LozinkaLabel = new System.Windows.Forms.Label();
            this.LozinkaTextBox = new System.Windows.Forms.TextBox();
            this.PrikaziLozinkuCheckBox = new System.Windows.Forms.CheckBox();
            this.PrijavaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(27, 25);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(285, 129);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPictureBox.TabIndex = 0;
            this.LogoPictureBox.TabStop = false;
            // 
            // KorisnickoImeLabel
            // 
            this.KorisnickoImeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KorisnickoImeLabel.AutoSize = true;
            this.KorisnickoImeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.KorisnickoImeLabel.Location = new System.Drawing.Point(24, 190);
            this.KorisnickoImeLabel.Name = "KorisnickoImeLabel";
            this.KorisnickoImeLabel.Size = new System.Drawing.Size(113, 18);
            this.KorisnickoImeLabel.TabIndex = 1;
            this.KorisnickoImeLabel.Text = "Korisnicko ime:";
            // 
            // KorisnickoImeTextBox
            // 
            this.KorisnickoImeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KorisnickoImeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KorisnickoImeTextBox.Location = new System.Drawing.Point(27, 211);
            this.KorisnickoImeTextBox.MinimumSize = new System.Drawing.Size(285, 30);
            this.KorisnickoImeTextBox.Name = "KorisnickoImeTextBox";
            this.KorisnickoImeTextBox.Size = new System.Drawing.Size(285, 30);
            this.KorisnickoImeTextBox.TabIndex = 0;
            // 
            // LozinkaLabel
            // 
            this.LozinkaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LozinkaLabel.AutoSize = true;
            this.LozinkaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.LozinkaLabel.Location = new System.Drawing.Point(24, 262);
            this.LozinkaLabel.Name = "LozinkaLabel";
            this.LozinkaLabel.Size = new System.Drawing.Size(64, 18);
            this.LozinkaLabel.TabIndex = 3;
            this.LozinkaLabel.Text = "Lozinka:";
            // 
            // LozinkaTextBox
            // 
            this.LozinkaTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LozinkaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LozinkaTextBox.Location = new System.Drawing.Point(27, 283);
            this.LozinkaTextBox.MinimumSize = new System.Drawing.Size(285, 30);
            this.LozinkaTextBox.Name = "LozinkaTextBox";
            this.LozinkaTextBox.Size = new System.Drawing.Size(285, 30);
            this.LozinkaTextBox.TabIndex = 1;
            this.LozinkaTextBox.UseSystemPasswordChar = true;
            // 
            // PrikaziLozinkuCheckBox
            // 
            this.PrikaziLozinkuCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrikaziLozinkuCheckBox.AutoSize = true;
            this.PrikaziLozinkuCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.PrikaziLozinkuCheckBox.Location = new System.Drawing.Point(105, 341);
            this.PrikaziLozinkuCheckBox.Name = "PrikaziLozinkuCheckBox";
            this.PrikaziLozinkuCheckBox.Size = new System.Drawing.Size(124, 22);
            this.PrikaziLozinkuCheckBox.TabIndex = 5;
            this.PrikaziLozinkuCheckBox.Text = "Prikazi lozinku";
            this.PrikaziLozinkuCheckBox.UseVisualStyleBackColor = true;
            this.PrikaziLozinkuCheckBox.CheckedChanged += new System.EventHandler(this.PrikaziLozinkuCheckBox_CheckedChanged);
            // 
            // PrijavaButton
            // 
            this.PrijavaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrijavaButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.PrijavaButton.FlatAppearance.BorderSize = 0;
            this.PrijavaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrijavaButton.ForeColor = System.Drawing.Color.White;
            this.PrijavaButton.Location = new System.Drawing.Point(27, 396);
            this.PrijavaButton.Name = "PrijavaButton";
            this.PrijavaButton.Size = new System.Drawing.Size(285, 43);
            this.PrijavaButton.TabIndex = 2;
            this.PrijavaButton.Text = "Prijava";
            this.PrijavaButton.UseVisualStyleBackColor = false;
            this.PrijavaButton.Click += new System.EventHandler(this.PrijavaButton_Click);
            // 
            // LogInForm
            // 
            this.AcceptButton = this.PrijavaButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(341, 463);
            this.Controls.Add(this.PrijavaButton);
            this.Controls.Add(this.PrikaziLozinkuCheckBox);
            this.Controls.Add(this.LozinkaTextBox);
            this.Controls.Add(this.LozinkaLabel);
            this.Controls.Add(this.KorisnickoImeTextBox);
            this.Controls.Add(this.KorisnickoImeLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label KorisnickoImeLabel;
        private System.Windows.Forms.TextBox KorisnickoImeTextBox;
        private System.Windows.Forms.Label LozinkaLabel;
        private System.Windows.Forms.TextBox LozinkaTextBox;
        private System.Windows.Forms.CheckBox PrikaziLozinkuCheckBox;
        private System.Windows.Forms.Button PrijavaButton;
    }
}