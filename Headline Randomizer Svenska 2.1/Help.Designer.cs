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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtbGames = new System.Windows.Forms.RichTextBox();
            this.pGames = new System.Windows.Forms.Panel();
            this.pScenes = new System.Windows.Forms.Panel();
            this.rtbScenes = new System.Windows.Forms.RichTextBox();
            this.pCustom = new System.Windows.Forms.Panel();
            this.rtbCustom = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.pGames.SuspendLayout();
            this.pScenes.SuspendLayout();
            this.pCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 537);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pCustom);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(361, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Egen mening";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pScenes);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(361, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Scener";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // pScenes
            // 
            this.pScenes.BackColor = System.Drawing.SystemColors.Control;
            this.pScenes.Controls.Add(this.rtbScenes);
            this.pScenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScenes.Location = new System.Drawing.Point(0, 0);
            this.pScenes.Name = "pScenes";
            this.pScenes.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.pScenes.Size = new System.Drawing.Size(361, 418);
            this.pScenes.TabIndex = 2;
            // 
            // rtbScenes
            // 
            this.rtbScenes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbScenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbScenes.Location = new System.Drawing.Point(20, 10);
            this.rtbScenes.Margin = new System.Windows.Forms.Padding(0);
            this.rtbScenes.Name = "rtbScenes";
            this.rtbScenes.ReadOnly = true;
            this.rtbScenes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbScenes.Size = new System.Drawing.Size(341, 408);
            this.rtbScenes.TabIndex = 0;
            this.rtbScenes.Text = "";
            // 
            // pCustom
            // 
            this.pCustom.BackColor = System.Drawing.SystemColors.Control;
            this.pCustom.Controls.Add(this.rtbCustom);
            this.pCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCustom.Location = new System.Drawing.Point(3, 3);
            this.pCustom.Name = "pCustom";
            this.pCustom.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.pCustom.Size = new System.Drawing.Size(355, 412);
            this.pCustom.TabIndex = 2;
            // 
            // rtbCustom
            // 
            this.rtbCustom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCustom.Location = new System.Drawing.Point(20, 10);
            this.rtbCustom.Margin = new System.Windows.Forms.Padding(0);
            this.rtbCustom.Name = "rtbCustom";
            this.rtbCustom.ReadOnly = true;
            this.rtbCustom.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbCustom.Size = new System.Drawing.Size(335, 402);
            this.rtbCustom.TabIndex = 0;
            this.rtbCustom.Text = "";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(369, 537);
            this.Controls.Add(this.tabControl1);
            this.Name = "Help";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.SizeChanged += new System.EventHandler(this.Help_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.pGames.ResumeLayout(false);
            this.pScenes.ResumeLayout(false);
            this.pCustom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbGames;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel pGames;
        private System.Windows.Forms.Panel pScenes;
        private System.Windows.Forms.RichTextBox rtbScenes;
        private System.Windows.Forms.Panel pCustom;
        private System.Windows.Forms.RichTextBox rtbCustom;
    }
}