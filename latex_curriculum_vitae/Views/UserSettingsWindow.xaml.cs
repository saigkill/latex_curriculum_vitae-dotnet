﻿// Copyright (C) 2020 Sascha Manns <Sascha.Manns@outlook.de>
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
using System.Configuration;
using System.Windows;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// Interaktionslogik für UserSettingsWindow.xaml
    /// </summary>
    public partial class UserSettingsWindow : Window
    {
        #region Construct User Settings Window
        public UserSettingsWindow()
        {
            InitializeComponent();
            this.Title = "Latex Curriculum Vitae" + " - " + Properties.Resources.UsHeader;

            ConfigurationManager.RefreshSection("appSettings");
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
            txtBitlyToken.Text = Configuration.GetSetting("bitly-token");
        }
        #endregion

        #region Save Settings
        public void BtnSave_Click(object sender, EventArgs e)
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
            Configuration.SetSetting("bitly-token", txtBitlyToken.Text);
            ConfigurationManager.RefreshSection("appSettings");

            this.Close();
        }
        #endregion

        public void BtnHelp_Click(object sender, EventArgs e)
        {
            Setup.GetOnlineDocumentation("cha.installation.html");
        }

        #region Exit Application
        public void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
