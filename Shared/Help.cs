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
                    tabsInfo.TabPages[2].Text = "Scener";
                    tabsInfo.TabPages[3].Text = "Grammatik";
                    InsertText(rtbAbout, "TextSwe\\Omappen.rtf");
                    InsertText(rtbGames, "TextSwe\\Lekar.rtf");
                    InsertText(rtbScenes, "TextSwe\\Scener.rtf");
                    InsertText(rtbGrammar, "TextSwe\\Grammatik.rtf");

                }
                else
                {
                    string message = "Full version only. Currently there is only a full version in Swedish. However, there will be a full English version if there's enough demand.";
                    tabsInfo.TabPages[0].Text = "About";
                    tabsInfo.TabPages[1].Text = "Games";
                    tabsInfo.TabPages[2].Text = "Scenes";
                    tabsInfo.TabPages[3].Text = "Grammar";
                    InsertText(rtbAbout, "TextEng\\About.rtf");
                    InsertText(rtbGames, "TextEng\\Games.rtf");
                    rtbScenes.Text = message;
                    rtbGrammar.Text = message;

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
