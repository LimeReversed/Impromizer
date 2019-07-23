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
using System.Data.SQLite;

namespace Headline_Randomizer
{
    public partial class LanguageForm : Form
    {
        

        public LanguageForm()
        {
            InitializeComponent();

            lblEnglish.Visible = Common.fullVersion;
        }

        private void BtnEnglish_Click(object sender, EventArgs e)
        {
            Config.SaveRegValue("Language", "English");

            // Start the English version
            Process.Start($"{Common.baseDirectoryPath}Impromizer English.exe");
            this.Close();
        }

        private void btnSvenska_Click(object sender, EventArgs e)
        {
            Config.SaveRegValue("Language", "Swedish");
            Process.Start($"{Common.baseDirectoryPath}Impromizer Swedish.exe");
            this.Close();
        }
    }
}
