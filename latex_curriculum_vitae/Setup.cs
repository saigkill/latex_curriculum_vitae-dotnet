using System;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Windows.Input;
using System.Linq.Expressions;

namespace latex_curriculum_vitae
{
    class Setup
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public Setup()
        {
            CheckLatexPath();
            CheckDocumentsPath();            
        }

        private void CheckLatexPath()
        {
            string main = @"C:\texlive";
            try
            {
                Directory.SetCurrentDirectory(main);
            }
            catch(Exception e)
            {
                MessageBox.Show("Sadly i havent found TexLive. Now i open a Browser where you can download it. Please close this app, download texlive and install it. Then rerun this app again" + e, "latex_curriculum_vitae-Check LaTEX", MessageBoxButton.OK, MessageBoxImage.Error);
                string targetURL = @"https://www.tug.org/texlive/acquire-netinstall.html";
                Process.Start(targetURL);

            }                            
        }

        private void CheckDocumentsPath()
        {            
            string lcvDocsPath = Path.Combine(appDataPath, "latex_curriculum_vitae", "Letter_of_Application", "letter_of_application.tex");
            bool lcvDocsPathExists = File.Exists(lcvDocsPath);            
            if (lcvDocsPathExists == false)
            {
                string targetPath = Path.Combine(appDataPath, "latex_curriculum_vitae");
                MessageBox.Show("It looks like you started this app the first time. I prepare now the directory structure and copy the needed files to: " + targetPath + ".", "latex_curriculum_vitae-Setup", MessageBoxButton.OK, MessageBoxImage.Information);
                CreateDocumentsPath();
                CopyDocuments();
                MessageBox.Show("Please close the App and follow the documentation on:", "latex_curriculum_vitae-Setup", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CreateDocumentsPath()
        {                 
            string[] lcvDocsPath = {Path.Combine(appDataPath, "latex_curriculum_vitae", "Letter_of_Application"), Path.Combine(appDataPath, "latex_curriculum_vitae", "Curriculum_Vitae"), Path.Combine(appDataPath, "latex_curriculum_vitae", "Pictures"),
                Path.Combine(appDataPath, "latex_curriculum_vitae", "Appendix"), Path.Combine(appDataPath, "latex_curriculum_vitae", "Appendix", "Bibliography"), Path.Combine(appDataPath, "latex_curriculum_vitae", "Appendix", "Certificates"),
                Path.Combine(appDataPath, "latex_curriculum_vitae", "Appendix", "Certificates_of_Employment") };
            foreach (string docspath in lcvDocsPath)
            {
                Directory.CreateDirectory(docspath);
            }                        
        }

        private void CopyDocuments()
        {
            // https://stackoverflow.com/questions/17782707/how-to-cut-out-a-part-of-a-path/17782741
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;            
            String[] extract = Regex.Split(currentDir, "bin");
            String main = extract[0].TrimEnd('\\');
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
        }

    }
}
