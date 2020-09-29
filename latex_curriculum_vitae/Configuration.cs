using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;

namespace latex_curriculum_vitae
{
    static class Configuration
    {        
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetSetting(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            MessageBox.Show(config.FilePath);
            var entry = config.AppSettings.Settings[key];
            if (entry == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;

            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
