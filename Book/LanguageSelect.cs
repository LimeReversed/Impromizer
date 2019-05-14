using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Common
{
    public class LanguageSelect
    {
        public static void Reset()
        {
            SaveLanguageSelection("None");
        }

        public static string GetLanguageSelection()
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Lime the fruit\\Impromizer");
            string r = rk.GetValue("Language", "None").ToString();
            rk.Close();
            return r;
        }

        public static void SaveLanguageSelection(string language)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Lime the fruit\\Impromizer");
            rk.SetValue("Language", language, RegistryValueKind.String);
            rk.Close();
        }
    }
}
