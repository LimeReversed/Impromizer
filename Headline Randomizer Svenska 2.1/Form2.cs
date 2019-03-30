using System;
using System.Windows.Forms;
using System.Drawing;

namespace Headline_Randomizer
{
    public partial class PresentationWindow : Form
    {
        public Form1 otherForm;

        public PresentationWindow()
        {
            InitializeComponent();
        }

        private void tbxResult_TextChanged(object sender, EventArgs e)
        {
            otherForm.saveResultToolStripMenuItem.ForeColor = Color.White;
            if (Db.GetValue($"SELECT Mening FROM TblSavedResults WHERE Mening = '{tbxResult.Text}'") == tbxResult.Text && tbxResult.Text != "")
            {
                otherForm.saveResultToolStripMenuItem.ForeColor = Color.Yellow;
            }
        }
    }
}
