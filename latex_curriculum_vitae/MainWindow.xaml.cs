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
            
            _ = new Setup();
            User myuser = new User();
            JobApplication myapplication = new JobApplication(txtURL.Text, txtEmail.Text, txtJobtitle.Text);
            Company mycompany = new Company(txtCompanyName.Text, txtCompanyStreet.Text, Convert.ToInt32(txtZIP.Text), txtCity.Text);
            ComboBoxItem typeItem = (ComboBoxItem)cboGender.SelectedItem;
            string gender = typeItem.Content.ToString();
            Contact mycontact = new Contact(txtContactName.Text, gender);
            addressline = mycontact.Addressline(mycompany.Name, mycontact.Name, mycontact.Gender, mycompany.Street, mycompany.City);
            Build build = new Build();
            build.CreateApplicationConfig(myapplication.Jobtitle, mycompany.Name, mycontact.Name, mycompany.Street, mycompany.City, mycontact.Salutation, myuser.Subject, addressline);
            build.CompileApplication();
            build.CombineApplication(myuser.Firstname, myuser.Familyname);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
