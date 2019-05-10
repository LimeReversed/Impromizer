namespace Headline_Randomizer
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pAbout = new System.Windows.Forms.Panel();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pGames = new System.Windows.Forms.Panel();
            this.rtbGames = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.pAbout.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pGames.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 537);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pAbout);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(361, 505);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Om appen";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pAbout
            // 
            this.pAbout.BackColor = System.Drawing.SystemColors.Control;
            this.pAbout.Controls.Add(this.rtbAbout);
            this.pAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAbout.ForeColor = System.Drawing.Color.White;
            this.pAbout.Location = new System.Drawing.Point(3, 3);
            this.pAbout.Name = "pAbout";
            this.pAbout.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.pAbout.Size = new System.Drawing.Size(355, 499);
            this.pAbout.TabIndex = 2;
            // 
            // rtbAbout
            // 
            this.rtbAbout.BackColor = System.Drawing.SystemColors.Control;
            this.rtbAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAbout.ForeColor = System.Drawing.Color.White;
            this.rtbAbout.Location = new System.Drawing.Point(20, 10);
            this.rtbAbout.Margin = new System.Windows.Forms.Padding(0);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.ReadOnly = true;
            this.rtbAbout.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbAbout.Size = new System.Drawing.Size(335, 489);
            this.rtbAbout.TabIndex = 0;
            this.rtbAbout.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.pGames);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(361, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lekar";
            // 
            // pGames
            // 
            this.pGames.BackColor = System.Drawing.SystemColors.Control;
            this.pGames.Controls.Add(this.rtbGames);
            this.pGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGames.ForeColor = System.Drawing.Color.White;
            this.pGames.Location = new System.Drawing.Point(0, 0);
            this.pGames.Name = "pGames";
            this.pGames.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.pGames.Size = new System.Drawing.Size(361, 505);
            this.pGames.TabIndex = 1;
            // 
            // rtbGames
            // 
            this.rtbGames.BackColor = System.Drawing.SystemColors.Control;
            this.rtbGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbGames.ForeColor = System.Drawing.Color.White;
            this.rtbGames.Location = new System.Drawing.Point(20, 10);
            this.rtbGames.Margin = new System.Windows.Forms.Padding(0);
            this.rtbGames.Name = "rtbGames";
            this.rtbGames.ReadOnly = true;
            this.rtbGames.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbGames.Size = new System.Drawing.Size(341, 495);
            this.rtbGames.TabIndex = 0;
            this.rtbGames.Text = "";
            this.rtbGames.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(369, 537);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 39);
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Help_Load);
            this.SizeChanged += new System.EventHandler(this.Help_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.pAbout.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pGames.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtbGames;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel pGames;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel pAbout;
        private System.Windows.Forms.RichTextBox rtbAbout;
    }
}