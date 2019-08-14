namespace Headline_Randomizer
{
    partial class SubscriptionDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubscriptionDialogue));
            this.btnGåVidare = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbFull = new System.Windows.Forms.RichTextBox();
            this.cbStoreId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGåVidare
            // 
            this.btnGåVidare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGåVidare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGåVidare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGåVidare.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGåVidare.ForeColor = System.Drawing.Color.White;
            this.btnGåVidare.Location = new System.Drawing.Point(167, 639);
            this.btnGåVidare.Name = "btnGåVidare";
            this.btnGåVidare.Size = new System.Drawing.Size(183, 56);
            this.btnGåVidare.TabIndex = 4;
            this.btnGåVidare.Text = "Gå vidare...";
            this.btnGåVidare.UseVisualStyleBackColor = false;
            this.btnGåVidare.Click += new System.EventHandler(this.BtnSvenska_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(178, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // rtbFull
            // 
            this.rtbFull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbFull.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbFull.ForeColor = System.Drawing.Color.White;
            this.rtbFull.Location = new System.Drawing.Point(20, 133);
            this.rtbFull.Margin = new System.Windows.Forms.Padding(0);
            this.rtbFull.Name = "rtbFull";
            this.rtbFull.ReadOnly = true;
            this.rtbFull.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbFull.Size = new System.Drawing.Size(477, 477);
            this.rtbFull.TabIndex = 6;
            this.rtbFull.TabStop = false;
            this.rtbFull.Text = "";
            this.rtbFull.TextChanged += new System.EventHandler(this.RtbAbout_TextChanged);
            // 
            // cbStoreId
            // 
            this.cbStoreId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbStoreId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbStoreId.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStoreId.ForeColor = System.Drawing.Color.White;
            this.cbStoreId.FormattingEnabled = true;
            this.cbStoreId.Items.AddRange(new object[] {
            "9N66GC16QH94"});
            this.cbStoreId.Location = new System.Drawing.Point(167, 606);
            this.cbStoreId.Name = "cbStoreId";
            this.cbStoreId.Size = new System.Drawing.Size(183, 26);
            this.cbStoreId.TabIndex = 7;
            this.cbStoreId.TabStop = false;
            this.cbStoreId.TextChanged += new System.EventHandler(this.CbStoreId_TextChanged);
            // 
            // SubscriptionDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(516, 723);
            this.Controls.Add(this.cbStoreId);
            this.Controls.Add(this.rtbFull);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGåVidare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SubscriptionDialogue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubscriptionDialogue";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SubscriptionDialogue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGåVidare;
        private System.Windows.Forms.RichTextBox rtbFull;
        private System.Windows.Forms.ComboBox cbStoreId;
    }
}