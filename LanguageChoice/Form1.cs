using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace LanguageChoice
{
    public partial class LanguageChoice : Form
    {
        public LanguageChoice()
        {
            InitializeComponent();

            
        }

        private void BtnEnglish_Click(object sender, EventArgs e)
        {
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Properties.Settings.Default.Language = "English";
            Properties.Settings.Default.Save();

            // Start the English version
            string path2 = $"{AppDomain.CurrentDomain.BaseDirectory}";
            string newPath = Path.GetFullPath(Path.Combine(path2, @"..\"));
            Process.Start($"{newPath}Impromizer Free English\\Impromizer Free English.exe");
            this.Close();
        }

        private void btnSvenska_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "Swedish";
            Properties.Settings.Default.Save();

            string path2 = $"{AppDomain.CurrentDomain.BaseDirectory}";
            string newPath = Path.GetFullPath(Path.Combine(path2, @"..\"));
            Process.Start($"{newPath}Impromizer Free Swedish\\Headline Randomizer Svenska 2.1 Free.exe");
            this.Close();
        }
    }
}
