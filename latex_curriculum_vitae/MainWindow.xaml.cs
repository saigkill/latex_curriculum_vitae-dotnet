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

using System;
using System.Windows;
using System.Windows.Controls;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Initialize Main
        public MainWindow()
        {
            InitializeComponent();
            Setup.CheckAppConfig();

        }
        #endregion

        #region Generating job application
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            #region Private Variables
            string addressline;
            bool compemail_set;
            #endregion

            #region Setup            
            Setup.Cleanup();
            Setup.CheckLatexPath();
            Setup.CheckDocumentsPath();
            #endregion

            #region Settings
            User myuser = new User();
            #endregion

            #region JobApplication Data
            JobApplication myapplication = new JobApplication(txtURL.Text, txtEmail.Text, txtJobtitle.Text);

            if (myapplication.Email == "")
            {
                compemail_set = false;
            }
            else
            {
                compemail_set = true;
            }

            Company company;
            if (txtCompanyStreet.Text == "" || txtZIP.Text == "" || txtCity.Text == "")
            {
                company = new Company(txtCompanyName.Text);
            }
            else
            {
                company = new Company(txtCompanyName.Text, txtCompanyStreet.Text, Convert.ToInt32(txtZIP.Text), txtCity.Text);
            }

            ComboBoxItem typeItem = (ComboBoxItem)cboGender.SelectedItem;
            string gender = typeItem.Content.ToString();

            Contact contact = new Contact(txtContactName.Text, gender);
            addressline = contact.Addressline(company.Name, contact.Name, contact.Gender, company.Street, company.City);
            #endregion

            #region Build, Compile and Send
            Build.PrepareBuild();
            string subject = Build.GetSubject(myuser.Subjectprefix, myapplication.Jobtitle);
            Build.CreateApplicationConfig(myapplication.Jobtitle, company.Name, contact.Name, company.Street, company.City, contact.Salutation, subject, addressline);
            Build.CompileApplication();
            Build.CombineApplication(myuser.Firstname, myuser.Familyname);

            if (compemail_set == false)
            {
                Build.OpenExplorer();

            }
            else
            {
                subject = Build.GetEmailSubject(myuser.Subjectprefix, myapplication.Jobtitle);
                string finalpdf = Build.GetFinalPdfName(myuser.Firstname, myuser.Familyname);
                Email.CreateMessage(myuser.Firstname, myuser.Familyname, myuser.Email, contact.Name, myapplication.Email, subject, contact.Salutation, finalpdf, myuser.SmtpServer, myuser.SmtpUser, myuser.SmtpPass, myuser.SmtpPort);
            }
            #endregion

            #region Clean UI
            txtCity.Text = "";
            txtCompanyName.Text = "";
            txtCompanyStreet.Text = "";
            txtContactName.Text = "";
            txtEmail.Text = "";
            txtJobtitle.Text = "";
            txtURL.Text = "";
            txtZIP = null;
            #endregion
        }
        #endregion

        #region Exit App
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Configure App
        private void BtnConfiguration_Click(object sender, EventArgs e)
        {
            Window settings = new UserSettingsWindow();
            settings.Show();
        }
        #endregion

        #region Open Dataview
        private void BtnDatabase_Click(object sender, EventArgs e)
        {
            //Mycontext = new JobApplicationDataDbContext();
            //Window database = new DatabaseWindow(Mycontext);
            //database.Show();
        }
        #endregion
    }
}
