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

namespace Headline_Randomizer
{
    public partial class LanguageForm : Form
    {
        

        public LanguageForm()
        {
            InitializeComponent();
        }

        private void BtnEnglish_Click(object sender, EventArgs e)
        {
            Version.SaveLanguageSelection("English");

            // Copy database
            string toPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer";
            string fromPath = $"{AppDomain.CurrentDomain.BaseDirectory}";

            if (!Directory.Exists($"{toPath}"))
            {
                Directory.CreateDirectory($"{toPath}");
                
                System.IO.File.Copy($"{fromPath}Databases\\WordsDatabaseEnglish.db3",
                                    $"{toPath}\\WordsDatabaseEnglish.db3", true);
            }
            else if (Directory.Exists($"{toPath}")
                    && !File.Exists($"{toPath}\\WordsDatabaseEnglish.db3"))
            {
                System.IO.File.Copy($"{fromPath}Databases\\WordsDatabaseEnglish.db3",
                                    $"{toPath}\\WordsDatabaseEnglish.db3", true);
            }
            else if (Directory.Exists($"{toPath}")
                    && File.Exists($"{toPath}\\WordsDatabaseEnglish.db3"))
            {
                File.Delete($"{toPath}\\WordsDatabaseEnglish.db3");
                System.IO.File.Copy($"{fromPath}Databases\\WordsDatabaseEnglish.db3",
                                    $"{toPath}\\WordsDatabaseEnglish.db3", true);
            }
            else
            {
                MessageBox.Show($"The database could not be copied and might not work correctly. Try reinstalling.");
            }

            // Start the English version
            Process.Start($"{fromPath}Impromizer English.exe");
            this.Close();
        }

        private void btnSvenska_Click(object sender, EventArgs e)
        {
            Version.SaveLanguageSelection("Swedish");

            string toPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer";
            string fromPath = $"{AppDomain.CurrentDomain.BaseDirectory}";

            if (!Directory.Exists($"{toPath}"))
            {

                Directory.CreateDirectory($"{toPath}");
                System.IO.File.Copy($"{fromPath}Databases\\WordsDatabaseSwedish.db3",
                                    $"{toPath}\\WordsDatabaseSwedish.db3", true);
            }
            else if (Directory.Exists($"{toPath}")
                    && !File.Exists($"{toPath}\\WordsDatabaseSwedish.db3"))
            {
                System.IO.File.Copy($"{fromPath}Databases\\WordsDatabaseSwedish.db3",
                                    $"{toPath}\\WordsDatabaseSwedish.db3", true);
            }
            else if (Directory.Exists($"{toPath}")
                    && File.Exists($"{toPath}\\WordsDatabaseSwedish.db3"))
            {
                File.Delete($"{toPath}\\WordsDatabaseSwedish.db3");
                System.IO.File.Copy($"{fromPath}Databases\\WordsDatabaseSwedish.db3",
                                    $"{toPath}\\WordsDatabaseSwedish.db3", true);
            }
            else
            {
                MessageBox.Show($"Databasen kunde inte kopieras. Programmet kanske inte fungerar korrekt.");
            }

            Process.Start($"{fromPath}Impromizer Swedish.exe");
            this.Close();
        }
    }
}
