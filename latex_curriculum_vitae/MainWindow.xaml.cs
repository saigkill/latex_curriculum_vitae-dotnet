using latex_curriculum_vitae.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Setup.CheckAppConfig();

        }

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
            } else
            {
                compemail_set = true;
            }

            Company company;
            if (txtCompanyStreet.Text == "" || txtZIP.Text == "" || txtCity.Text == "")
            {
                company = new Company(txtCompanyName.Text);
            } else
            {
                company = new Company(txtCompanyName.Text, txtCompanyStreet.Text, Convert.ToInt32(txtZIP.Text), txtCity.Text);
            }
                        
            ComboBoxItem typeItem = (ComboBoxItem)cboGender.SelectedItem;
            string gender = typeItem.Content.ToString();            
            
            Contact contact = new Contact(txtContactName.Text, gender);
            addressline = contact.Addressline(company.Name, contact.Name, contact.Gender, company.Street, company.City);
            #endregion

            #region Build, Compile and Send
            Build build = new Build();
            string subject = build.GetSubject(myuser.Subject, myapplication.Jobtitle);
            build.CreateApplicationConfig(myapplication.Jobtitle, company.Name, contact.Name, company.Street, company.City, contact.Salutation, subject, addressline);
            build.CompileApplication();
            build.CombineApplication(myuser.Firstname, myuser.Familyname);
            
            if(compemail_set == false)
            {
                build.OpenExplorer();

            } else
            {
                subject = build.GetEmailSubject(myuser.Subject, myapplication.Jobtitle);
                string finalpdf = build.GetFinalPdfName(myuser.Firstname, myuser.Familyname);
                Email email = new Email();
                email.CreateMessage(myuser.Firstname, myuser.Familyname, myuser.Email, contact.Name, myapplication.Email, subject, contact.Salutation, finalpdf, myuser.SmtpServer, myuser.SmtpUser, myuser.SmtpPass, myuser.SmtpPort);
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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConfiguration_Click(object sender, EventArgs e)
        {
            Window settings = new UserSettingsWindow();
            settings.Show();
        }

        private void BtnDatabase_Click(object sender, EventArgs e)
        {
            JobApplicationDbContext context;
            Window database = new DatabaseWindow(context);
            database.Show();
        }
    }
}
