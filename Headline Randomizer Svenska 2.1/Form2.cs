using System;
using System.Windows.Forms;
using System.Drawing;

namespace Headline_Randomizer
{
    public partial class PresentationWindow : Form
    {
        public PresentationWindow()
        {
            InitializeComponent();
        }

        private void tbxResult_TextChanged(object sender, EventArgs e)
        {
            Form1.saveResultToolStripMenuItem.ForeColor = Color.White;
            if (Db.GetValue($"SELECT Lines FROM TblSavedResults WHERE Lines = '{tbxResult.Text}'") == tbxResult.Text)
            {
                Form1.saveResultToolStripMenuItem.ForeColor = Color.Yellow;
            }
        }
    }
}
