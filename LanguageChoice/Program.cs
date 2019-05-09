using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace LanguageChoice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.Language == "English")
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}";
                string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));
                Process.Start($"{newPath}Impromizer Free English\\Impromizer Free English.exe");
            }
            else if (Properties.Settings.Default.Language == "Swedish")
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}";
                string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));
                Process.Start($"{newPath}Impromizer Free Swedish\\Headline Randomizer Svenska 2.1 Free.exe");
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LanguageChoice());
            }
        }
    }
}
