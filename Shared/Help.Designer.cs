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
            this.tabsInfo = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbGames = new System.Windows.Forms.RichTextBox();
            this.tabsInfo.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsInfo
            // 
            this.tabsInfo.Controls.Add(this.tabPage4);
            this.tabsInfo.Controls.Add(this.tabPage1);
            this.tabsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabsInfo.Location = new System.Drawing.Point(0, 0);
            this.tabsInfo.Name = "tabsInfo";
            this.tabsInfo.Padding = new System.Drawing.Point(0, 0);
            this.tabsInfo.SelectedIndex = 0;
            this.tabsInfo.Size = new System.Drawing.Size(369, 537);
            this.tabsInfo.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rtbAbout);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage4.Size = new System.Drawing.Size(361, 505);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rtbAbout
            // 
            this.rtbAbout.BackColor = System.Drawing.SystemColors.Control;
            this.rtbAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAbout.ForeColor = System.Drawing.Color.White;
            this.rtbAbout.Location = new System.Drawing.Point(3, 3);
            this.rtbAbout.Margin = new System.Windows.Forms.Padding(0);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.ReadOnly = true;
            this.rtbAbout.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbAbout.Size = new System.Drawing.Size(355, 499);
            this.rtbAbout.TabIndex = 1;
            this.rtbAbout.TabStop = false;
            this.rtbAbout.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.rtbGames);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(361, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Games";
            // 
            // rtbGames
            // 
            this.rtbGames.BackColor = System.Drawing.SystemColors.Control;
            this.rtbGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbGames.ForeColor = System.Drawing.Color.White;
            this.rtbGames.Location = new System.Drawing.Point(0, 0);
            this.rtbGames.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.rtbGames.Name = "rtbGames";
            this.rtbGames.ReadOnly = true;
            this.rtbGames.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbGames.Size = new System.Drawing.Size(361, 505);
            this.rtbGames.TabIndex = 1;
            this.rtbGames.TabStop = false;
            this.rtbGames.Text = "";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(369, 537);
            this.Controls.Add(this.tabsInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(298, 50);
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Help_FormClosed);
            this.tabsInfo.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabControl tabsInfo;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox rtbAbout;
        private System.Windows.Forms.RichTextBox rtbGames;
    }
}