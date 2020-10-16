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
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// This class contains methods for doing the setup
    /// </summary>
    static class Setup
    {
        static readonly string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// This method checks, if the config file is already present. Otherwise it launches the UserSettings Window.
        /// </summary>
        public static void CheckAppConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            bool lcvConfigPathExists = File.Exists(config.FilePath);

            if (lcvConfigPathExists == false)
            {
                MessageBox.Show(Properties.Resources.MsgSetupCheckConfig, Properties.Resources.MsgSetupCheckConfigHeader, MessageBoxButton.OK, MessageBoxImage.Information);

                Window settings = new UserSettingsWindow();
                settings.Show();
            }
        }

        /// <summary>
        /// This method checks, if LaTEX is already installed. Otherwise it opens the installation website.
        /// </summary>
        public static void CheckLatexPath()
        {
            string main = @"C:\texlive";
            try
            {
                Directory.SetCurrentDirectory(main);
            }
            catch (Exception e)
            {
                MessageBox.Show(Properties.Resources.MsgSetupCheckLatex + e, Properties.Resources.MsgSetupCheckLatexHeader, MessageBoxButton.OK, MessageBoxImage.Error);
                string targetURL = @"https://www.tug.org/texlive/acquire-netinstall.html";
                Process.Start(targetURL);

            }
        }

        /// <summary>
        /// This method copies by the first run a couple of files to the AppData directory.
        /// </summary>
        public static void CheckDocumentsPath()
        {
            string lcvDocsPath = Path.Combine(appDataPath, "latex_curriculum_vitae", "Letter_of_Application", "letter_of_application.tex");
            bool lcvDocsPathExists = File.Exists(lcvDocsPath);
            if (lcvDocsPathExists == false)
            {
                string targetPath = Path.Combine(appDataPath, "latex_curriculum_vitae");
                MessageBox.Show(Properties.Resources.MsgSetupCheckDocumentsCopy + " " + targetPath + ".", Properties.Resources.MsgSetupCheckDocumentHeader, MessageBoxButton.OK, MessageBoxImage.Information);
                CreateDocumentsPath();
                CopyDocuments();
                MessageBox.Show(Properties.Resources.MsgSetupCheckDocument, Properties.Resources.MsgSetupCheckDocumentHeader, MessageBoxButton.OK, MessageBoxImage.Information);
                GetOnlineDocumentation();
            }
        }

        /// <summary>
        /// This method launches the online documentation.
        /// </summary>

        public static void GetOnlineDocumentation()
        {
            string targetURL = @"https://saigkill.github.io/latex_curriculum_vitae-dotnet/";
            Process.Start(targetURL);
        }

        /// <summary>
        /// This method just creates the directory structure, what lcv expected.
        /// </summary>
        private static void CreateDocumentsPath()
        {
            string[] lcvDocsPath = {Path.Combine(appDataPath, "latex_curriculum_vitae", "Letter_of_Application"), Path.Combine(appDataPath, "latex_curriculum_vitae", "Curriculum_Vitae"), Path.Combine(appDataPath, "latex_curriculum_vitae", "Pictures"),
                Path.Combine(appDataPath, "latex_curriculum_vitae", "Appendix"), Path.Combine(appDataPath, "latex_curriculum_vitae", "Appendix", "Bibliography"), Path.Combine(appDataPath, "latex_curriculum_vitae", "Appendix", "Certificates"),
                Path.Combine(appDataPath, "latex_curriculum_vitae", "Appendix", "Certificates_of_Employment") };
            foreach (string docspath in lcvDocsPath)
            {
                Directory.CreateDirectory(docspath);
            }
        }

        /// <summary>
        /// This method copies a couple of needed files to the AppData directory.
        /// </summary>
        private static void CopyDocuments()
        {
            // https://stackoverflow.com/questions/17782707/how-to-cut-out-a-part-of-a-path/17782741
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] extract = Regex.Split(currentDir, "bin");
            string main = extract[0].TrimEnd('\\');
            string targetPath = Path.Combine(appDataPath, "latex_curriculum_vitae");

            // Letter of Application
            File.Copy(Path.Combine(main, "Attachments", "Letter_of_Application") + "\\letter_of_application.tex", Path.Combine(targetPath, "Letter_of_Application") + "\\letter_of_application.tex");

            // Curriculum Vitae
            File.Copy(Path.Combine(main, "Attachments", "Curriculum_Vitae", "curriculum_vitae.tex"), Path.Combine(targetPath, "Curriculum_Vitae", "curriculum_vitae.tex"));
            File.Copy(Path.Combine(main, "Attachments", "Curriculum_Vitae", "friggeri-cv.cls"), Path.Combine(targetPath, "Curriculum_Vitae", "friggeri-cv.cls"));

            // Pictures
            string[] picList = Directory.GetFiles(Path.Combine(main, "Attachments", "Pictures"), "*");
            string srcDir = Path.Combine(main, "Attachments", "Pictures");
            string destDir = Path.Combine(targetPath, "Pictures");
            foreach (string pic in picList)
            {
                // Remove path from the file name.
                string fName = pic.Substring(srcDir.Length + 1);

                // Use the Path.Combine method to safely append the file name to the path.
                // Will overwrite if the destination file already exists.
                File.Copy(Path.Combine(srcDir, fName), Path.Combine(destDir, fName), true);
            }

            // Bibliography
            File.Copy(Path.Combine(main, "Attachments", "Appendix", "Bibliography", "bibliography.bib"), Path.Combine(targetPath, "Appendix", "Bibliography", "bibliography.bib"));

            // Empty CSV file
            File.Copy(Path.Combine(main, "Attachments", "CSV", "JobApplications.csv"), Path.Combine(targetPath, "JobApplications.csv"));
        }

        /// <summary>
        /// This method cleans up the temporary directory.
        /// </summary>
        public static void Cleanup()
        {
            string tmpDir = Path.GetTempPath();
            string mytmpDir = Path.Combine(tmpDir, "latex_curriculum_vitae");
            Directory.SetCurrentDirectory(mytmpDir);

            string[] delete = Directory.GetFiles(mytmpDir);

            foreach (string del in delete)
            {
                File.Delete(del);
            };

        }
    }
}
