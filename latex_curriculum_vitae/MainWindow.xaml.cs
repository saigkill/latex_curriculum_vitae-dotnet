using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            string addressline;
            bool compemail_set;
            
            Setup mysetup = new Setup();
            mysetup.Cleanup();
            User myuser = new User();
            JobApplication myapplication = new JobApplication(txtURL.Text, txtEmail.Text, txtJobtitle.Text);
            
            if (myapplication.Email == "")
            {
                compemail_set = false;
            } else
            {
                compemail_set = true;
            }

            Company company = new Company(txtCompanyName.Text, txtCompanyStreet.Text, Convert.ToInt32(txtZIP.Text), txtCity.Text);
            ComboBoxItem typeItem = (ComboBoxItem)cboGender.SelectedItem;
            string gender = typeItem.Content.ToString();
            Contact contact = new Contact(txtContactName.Text, gender);
            addressline = contact.Addressline(company.Name, contact.Name, contact.Gender, company.Street, company.City);
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
                string finalpdf = build.GetFinalPdfName(myuser.Firstname, myuser.Familyname);
                Email email = new Email();
                email.CreateMessage(myuser.Firstname, myuser.Familyname, myuser.Email, contact.Name, myapplication.Email, subject, contact.Salutation, finalpdf, myuser.SmtpServer, myuser.SmtpUser, myuser.SmtpPass);
            }            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
