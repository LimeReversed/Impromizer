namespace Headline_Randomizer
{
    partial class PresentationWindow
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
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxResult
            // 
            this.tbxResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxResult.CausesValidation = false;
            this.tbxResult.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxResult.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbxResult.Location = new System.Drawing.Point(10, 8);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ReadOnly = true;
            this.tbxResult.Size = new System.Drawing.Size(671, 105);
            this.tbxResult.TabIndex = 3;
            this.tbxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PresentationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(691, 120);
            this.ControlBox = false;
            this.Controls.Add(this.tbxResult);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PresentationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Presentation Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbxResult;

    }
}