using latex_curriculum_vitae.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// Interaktionslogik für DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {        
        JobApplicationDbContext context;
        JobApplicationData NewJobApplicationData = new JobApplicationData();
        JobApplicationData selectedJobApplicationData = new JobApplicationData();

        public DatabaseWindow(JobApplicationDbContext context)
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
