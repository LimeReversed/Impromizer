using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Headline_Randomizer
{
    public class Config
    {
        public static void ResetRegValue()
        {
            SaveRegValue("Language", "None");
        }

        public static string GetRegValue(string valueName, string defaultValue)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Lime the fruit\\Impromizer");
            string r = rk.GetValue($"{valueName}", $"{defaultValue}").ToString();
            rk.Close();
            return r;
        }

        public static void SaveRegValue(string valueName, string value)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Lime the fruit\\Impromizer");
            rk.SetValue(valueName, value, RegistryValueKind.String);
            rk.Close();
        }

        public static void DeleteRegValue(string valueName)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Lime the fruit\\Impromizer");
            rk.DeleteValue(valueName);
            rk.Close();
        }
    }
}
