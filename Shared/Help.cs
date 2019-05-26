using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Headline_Randomizer
{
    
    public partial class Help : Form
    {
        public Help()
        {
                InitializeComponent();
                this.Show();
                
        }

        public Help(int selectedindex, string language)
        {
            if (!Common.helpOpen)
            {
                InitializeComponent();
                this.Show();
                Common.helpOpen = true;
                tabsInfo.SelectedIndex = selectedindex;

                if (language == "Swedish")
                {
                    tabsInfo.TabPages[0].Text = "Om";
                    tabsInfo.TabPages[1].Text = "Lekar";
                    InsertText(rtbAbout, "TextSwe\\Omappen.rtf");
                    InsertText(rtbGames, "TextSwe\\Lekar.rtf");
            
                    //rtbScenes.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Text\\Scener.rtf");
                    //rtbCustom.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Text\\Grammatik.rtf");
                }
                else
                {
                    tabsInfo.TabPages[0].Text = "About";
                    tabsInfo.TabPages[1].Text = "Games";
                    InsertText(rtbAbout, "TextEng\\About.rtf");
                    InsertText(rtbGames, "TextEng\\Games.rtf");

                    //rtbScenes.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Text\\Scener.rtf");
                    //rtbCustom.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Text\\Grammatik.rtf");
                }
            }
            else { }
        }

        private void Help_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.helpOpen = false;
        }

        void InsertText(RichTextBox tbx, string file)
        {

            tbx.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}{file}");
            tbx.SelectAll();
            tbx.SelectionIndent += 20;
            tbx.SelectionRightIndent += 20;
            tbx.SelectionLength = 0;
            tbx.DeselectAll();
        }
    }
}
