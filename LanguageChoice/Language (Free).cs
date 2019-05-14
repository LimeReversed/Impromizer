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
using Common;

namespace Headline_Randomizer
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
            LanguageSelect.SaveLanguageSelection("English");

            // Copy database
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer";
            if (!Directory.Exists($"{path}"))
            {
                Directory.CreateDirectory($"{path}");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseEnglish.db3",
                                    $"{path}\\WordsDatabaseEnglish.db3", true);
            }
            else if (Directory.Exists($"{path}")
                    && !File.Exists($"{path}\\WordsDatabaseEnglish.db3"))
            {
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseEnglish.db3",
                                    $"{path}\\WordsDatabaseEnglish.db3", true);
            }
            else if (Directory.Exists($"{path}")
                    && File.Exists($"{path}\\WordsDatabaseEnglish.db3"))
            {
                File.Delete($"{path}\\WordsDatabaseEnglish.db3");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseEnglish.db3",
                                    $"{path}\\WordsDatabaseEnglish.db3", true);
            }
            else
            {
                MessageBox.Show($"The database could not be copied and might not work correctly. Try reinstalling.");
            }

            // Start the English version
            string path2 = $"{AppDomain.CurrentDomain.BaseDirectory}";
            string newPath = Path.GetFullPath(Path.Combine(path2, @"..\"));
            Process.Start($"{newPath}Impromizer Free English\\Impromizer Free English.exe");
            this.Close();
        }

        private void btnSvenska_Click(object sender, EventArgs e)
        {
            LanguageSelect.SaveLanguageSelection("Swedish");

            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer";
            if (!Directory.Exists($"{path}"))
            {

                Directory.CreateDirectory($"{path}");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseSwedish.db3",
                                    $"{path}\\WordsDatabaseSwedish.db3", true);
            }
            else if (Directory.Exists($"{path}")
                    && !File.Exists($"{path}\\WordsDatabaseSwedish.db3"))
            {
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseSwedish.db3",
                                    $"{path}\\WordsDatabaseSwedish.db3", true);
            }
            else if (Directory.Exists($"{path}")
                    && File.Exists($"{path}\\WordsDatabaseSwedish.db3"))
            {
                File.Delete($"{path}\\WordsDatabaseSwedish.db3");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseSwedish.db3",
                                    $"{path}\\WordsDatabaseSwedish.db3", true);
            }
            else
            {
                MessageBox.Show($"Databasen kunde inte kopieras. Programmet kanske inte fungerar korrekt.");
            }

            string path2 = $"{AppDomain.CurrentDomain.BaseDirectory}";
            string newPath = Path.GetFullPath(Path.Combine(path2, @"..\"));
            Process.Start($"{newPath}Impromizer Free Swedish\\Impromizer Free Swedish.exe");
            this.Close();
        }

        private void LanguageChoice_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
