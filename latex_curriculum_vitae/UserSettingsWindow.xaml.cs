using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
using System.Xml;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// Interaktionslogik für UserSettingsWindow.xaml
    /// </summary>
    public partial class UserSettingsWindow : Window
    {        
        public UserSettingsWindow()
        {
            InitializeComponent();
            
            txtFirstname.Text = Configuration.GetSetting("firstname");
            txtFamilyname.Text = Configuration.GetSetting("familyname");
            txtStreet.Text = Configuration.GetSetting("mystreet");
            txtCity.Text = Configuration.GetSetting("mycity");
            txtPhonenumber.Text = Configuration.GetSetting("myphone");
            txtEmail.Text = Configuration.GetSetting("myemail");
            txtBlog.Text = Configuration.GetSetting("myblog");            
            txtSMTPServer.Text = Configuration.GetSetting("smtp-server");
            txtSMTPUser.Text = Configuration.GetSetting("smtp-user");
            txtSMTPPass.Text = Configuration.GetSetting("smtp-pass");
            txtSMTPPort.Text = Configuration.GetSetting("smtp-port");            
        }        

        private void BtnSave_Click(object sender, EventArgs e)
        {            
            try
            {
                Configuration.SetSetting("firstname", txtFirstname.Text);
                Configuration.SetSetting("familyname", txtFamilyname.Text);
                Configuration.SetSetting("mystreet", txtStreet.Text);
                Configuration.SetSetting("mycity", txtCity.Text);
                Configuration.SetSetting("myphone", txtPhonenumber.Text);
                Configuration.SetSetting("myemail", txtEmail.Text);
                Configuration.SetSetting("myblog", txtBlog.Text);
                Configuration.SetSetting("smtp-server", txtSMTPServer.Text);
                Configuration.SetSetting("smtp-user", txtSMTPUser.Text);
                Configuration.SetSetting("smtp-pass", txtSMTPPass.Text);
                Configuration.SetSetting("smtp-port", txtSMTPPort.Text);
            }
            catch (ConfigurationErrorsException c)
            {
                MessageBox.Show("Error writing app settings: " + c, "latex_curriculum_vitae", MessageBoxButton.OK, MessageBoxImage.Error);                
            }

            this.Close();
        }
    }
}
