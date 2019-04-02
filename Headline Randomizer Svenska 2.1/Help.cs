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
            rtbGames.Rtf = File.ReadAllText(@"E:\Tresorit\Headline Randomizer\Headline Randomizer\Lekar.rtf");
            rtbGames.RightMargin = pGames.Size.Width - 65;

            rtbScenes.Rtf = File.ReadAllText(@"E:\Tresorit\Headline Randomizer\Headline Randomizer\Scener.rtf");
            rtbScenes.RightMargin = pScenes.Size.Width - 65;

            rtbCustom.Rtf = File.ReadAllText(@"E:\Tresorit\Headline Randomizer\Headline Randomizer\EgenMening.rtf");
            rtbCustom.RightMargin = pCustom.Size.Width - 65;
        }

        private void Help_SizeChanged(object sender, EventArgs e)
        {
            rtbGames.RightMargin = pGames.Size.Width - 65;
            rtbScenes.RightMargin = pScenes.Size.Width - 65;
            rtbCustom.RightMargin = pCustom.Size.Width - 65;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbGames.RightMargin = pGames.Size.Width - 65;
            rtbScenes.RightMargin = pScenes.Size.Width - 65;
            rtbCustom.RightMargin = pCustom.Size.Width - 65;
        }
    }
}
