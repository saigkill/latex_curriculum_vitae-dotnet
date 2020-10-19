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
            this.Title = Properties.Resources.MWTitle;

        }
        #endregion       

        public void BtnWriteJobApplication_Click(object sender, EventArgs e)
        {
            Window writeja = new WriteJobApplicationWindow();
            writeja.Show();
        }

        public void BtnSetUserSettings_Click(object sender, EventArgs e)
        {
            Window settings = new UserSettingsWindow();
            settings.Show();
        }

        public void BtnGoDatabase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is currently not supported.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
