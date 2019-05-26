﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (Debugger.IsAttached)
            {
                Version.Reset();
            }

            switch (Version.GetLanguageSelection())
            {
                case "English":
                    {
                        Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}Impromizer English.exe");
                        break;
                    }

                case "Swedish":
                    {
                        Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}Impromizer Swedish.exe");
                        break;
                    }

                default:
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new LanguageForm());
                    break;
            }
        }
    }
}