namespace Headline_Randomizer
{
    partial class LanguageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageForm));
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnSvenska = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEnglish = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnglish
            // 
            this.btnEnglish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEnglish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnglish.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnglish.ForeColor = System.Drawing.Color.White;
            this.btnEnglish.Location = new System.Drawing.Point(173, 259);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(183, 87);
            this.btnEnglish.TabIndex = 1;
            this.btnEnglish.TabStop = false;
            this.btnEnglish.Text = "English";
            this.btnEnglish.UseVisualStyleBackColor = false;
            this.btnEnglish.Click += new System.EventHandler(this.BtnEnglish_Click);
            // 
            // btnSvenska
            // 
            this.btnSvenska.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSvenska.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSvenska.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSvenska.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSvenska.ForeColor = System.Drawing.Color.White;
            this.btnSvenska.Location = new System.Drawing.Point(447, 259);
            this.btnSvenska.Name = "btnSvenska";
            this.btnSvenska.Size = new System.Drawing.Size(183, 87);
            this.btnSvenska.TabIndex = 2;
            this.btnSvenska.TabStop = false;
            this.btnSvenska.Text = "Svenska";
            this.btnSvenska.UseVisualStyleBackColor = false;
            this.btnSvenska.Click += new System.EventHandler(this.btnSvenska_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(275, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose language";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(314, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnglish.ForeColor = System.Drawing.Color.White;
            this.lblEnglish.Location = new System.Drawing.Point(208, 349);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(111, 16);
            this.lblEnglish.TabIndex = 4;
            this.lblEnglish.Text = "Free version only";
            this.lblEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEnglish);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSvenska);
            this.Controls.Add(this.btnEnglish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impromizer Language Selection";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnSvenska;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblEnglish;
    }
}

