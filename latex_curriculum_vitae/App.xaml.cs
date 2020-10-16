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

using System.Globalization;
using System.Threading;
using System.Windows;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //#region Private members
        //private readonly ServiceProvider serviceProvider;
        //#endregion

        //#region Constructor
        //public App()
        //{
        //    ServiceCollection services = new ServiceCollection();
        //    services.AddDbContext<JobApplicationDataDbContext>(options =>
        //    {
        //        options.UseSqlite("Data Source = JobApplications.db");
        //    });

        //    services.AddSingleton<DatabaseWindow>();
        //    serviceProvider = services.BuildServiceProvider();
        //}
        //#endregion

        #region Event Handlers
        private void OnStartup(object s, StartupEventArgs e)
        {
            string firstrun = Configuration.GetSetting("firstrun");
            if (firstrun == "Not Found")
            {
                Setup.CheckAppConfig();
                Setup.CheckLatexPath();
                Setup.CheckDocumentsPath();
                Configuration.SetSetting("firstrun", "false");
            }
            else
            {
#if DEBUG
                var vCulture = new CultureInfo("en-US");

                Thread.CurrentThread.CurrentCulture = vCulture;
                Thread.CurrentThread.CurrentUICulture = vCulture;
                CultureInfo.DefaultThreadCurrentCulture = vCulture;
                CultureInfo.DefaultThreadCurrentUICulture = vCulture;
#endif
                Window settings = new MainWindow();
                settings.Show();
            }
        }
        #endregion
    }
}
