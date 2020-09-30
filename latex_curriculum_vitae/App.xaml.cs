using latex_curriculum_vitae.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Private members
        private readonly ServiceProvider serviceProvider;
        #endregion

        #region Constructor
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<JobApplicationDataDbContext>(options =>
            {
                options.UseSqlite("Data Source = JobApplications.db");
            });

            services.AddSingleton<DatabaseWindow>();
            serviceProvider = services.BuildServiceProvider();
        }
        #endregion

        #region Event Handlers
        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            var databaseWindow = serviceProvider.GetService<DatabaseWindow>();
            mainWindow.Show();
        }
        #endregion
    }
}
