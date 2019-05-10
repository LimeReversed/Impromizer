using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Headline_Randomizer
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Help_Load(object sender, EventArgs e)
        {
            //richTextBox1.Rtf = @"{\rtf1\ Hello \b Lime\b0\";
            // Show what's in the focument at this path.
            rtbGames.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}TextEng\\Games.rtf");
            rtbGames.RightMargin = pGames.Size.Width - 65;

            //rtbScenes.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Text\\Scener.rtf");
            //rtbScenes.RightMargin = pScenes.Size.Width - 65;

            //rtbCustom.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Text\\Grammatik.rtf");
            //rtbCustom.RightMargin = pCustom.Size.Width - 65;

            rtbAbout.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}TextEng\\About.rtf");
            rtbAbout.RightMargin = pAbout.Size.Width - 65;
        }

        private void Help_SizeChanged(object sender, EventArgs e)
        {
            if (pAbout.Size.Width < 66 || pGames.Size.Width < 66)
            {

            }
            else
            {
                // Make the marigin follow the size of the window.
                rtbGames.RightMargin = pGames.Size.Width - 65;
                //rtbScenes.RightMargin = pScenes.Size.Width - 65;
                //rtbCustom.RightMargin = pCustom.Size.Width - 65;
                rtbAbout.RightMargin = pAbout.Size.Width - 65;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbGames.RightMargin = pGames.Size.Width - 65;
            //rtbScenes.RightMargin = pScenes.Size.Width - 65;
            //rtbCustom.RightMargin = pCustom.Size.Width - 65;
            rtbAbout.RightMargin = pAbout.Size.Width - 65;
        }
    }
}
