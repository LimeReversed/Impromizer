using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Common;

namespace Headline_Randomizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            switch (LanguageSelect.GetLanguageSelection())
            {
                case "English":
                    {
                        string path = $"{AppDomain.CurrentDomain.BaseDirectory}";
                        string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));
                        Process.Start($"{newPath}Impromizer Free English\\Impromizer Free English.exe");
                        break;
                    }

                case "Swedish":
                    {
                        string path = $"{AppDomain.CurrentDomain.BaseDirectory}";
                        string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));
                        Process.Start($"{newPath}Impromizer Free Swedish\\Impromizer Free Swedish.exe");
                        break;
                    }

                default:
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new LanguageChoice());
                    break;
            }
        }
    }
}
