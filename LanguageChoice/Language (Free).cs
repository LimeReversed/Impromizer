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
                // Sometimes the app gives me an error when an old database log is there after I copied a new database to that folder. The soution is to delete the log. 
                File.Delete($"{path}\\WordsDatabaseEnglish_log.ldf");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseEnglish.db3",
                                    $"{path}\\WordsDatabaseEnglish.db3", true);
            }
            else if (Directory.Exists($"{path}")
                    && File.Exists($"{path}\\WordsDatabaseEnglish.db3"))
            {
                File.Delete($"{path}\\WordsDatabase_log.ldf");
                File.Delete($"{path}\\WordsDatabaseEnglish.db3");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseEnglish.db3",
                                    $"{path}\\WordsDatabaseEnglish.db3", true);
            }
            else
            {
                MessageBox.Show($"Databasen could not be copied and might not work correctly. Try reinstalling.");
            }

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
                File.Delete($"{path}\\WordsDatabaseSwedish_log.ldf");
                System.IO.File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\WordsDatabaseSwedish.db3",
                                    $"{path}\\WordsDatabaseSwedish.db3", true);
            }
            else if (Directory.Exists($"{path}")
                    && File.Exists($"{path}\\WordsDatabaseSwedish.db3"))
            {
                File.Delete($"{path}\\WordsDatabase_log.ldf");
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
            Process.Start($"{newPath}Impromizer Free Swedish\\Headline Randomizer Svenska 2.1 Free.exe");
            this.Close();
        }
    }
}
