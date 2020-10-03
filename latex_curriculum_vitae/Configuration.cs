// Copyright (C) 2020 Sascha Manns <Sascha.Manns@outlook.de>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

// Dependencies

using System.Configuration;
using System.Windows;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// This class is for configure the project.
    /// </summary>
    static class Configuration
    {
        /// <summary>
        /// This method gets a specific information from the config file specified by its key name.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>string ConfigurationManager.AppSettings[key]</returns>
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// This method sets a specific information to the config file specified by its key name.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
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
