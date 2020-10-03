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

using latex_curriculum_vitae.Data;
using System.Linq;
using System.Windows;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// Interaktionslogik für DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        JobApplicationDataDbContext context;
        JobApplicationData NewJobApplicationData = new JobApplicationData();
        JobApplicationData selectedJobApplicationData = new JobApplicationData();

        public DatabaseWindow(JobApplicationDataDbContext context)
        {
            this.context = context;
            InitializeComponent();
            GetJobApplicationData();
            NewJobapplicationGrid.DataContext = NewJobApplicationData;
        }

        private void GetJobApplicationData()
        {
            JobApplicationDG.ItemsSource = context.JobApplications.ToList();
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
            context.JobApplications.Add(NewJobApplicationData);
            context.SaveChanges();
            GetJobApplicationData();
            NewJobApplicationData = new JobApplicationData();
            NewJobapplicationGrid.DataContext = NewJobApplicationData;
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.Update(selectedJobApplicationData);
            context.SaveChanges();
            GetJobApplicationData();
        }

        private void SelectJobApplicationToEdit(object s, RoutedEventArgs e)
        {
            selectedJobApplicationData = (s as FrameworkElement).DataContext as JobApplicationData;
            UpdateApplicationGrid.DataContext = selectedJobApplicationData;
        }

        private void DeleteApplication(object s, RoutedEventArgs e)
        {
            var applicationToDelete = (s as FrameworkElement).DataContext as JobApplicationData;
            context.JobApplications.Remove(applicationToDelete);
            context.SaveChanges();
            GetJobApplicationData();
        }
    }
}
