using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System.Drawing;
using System.Windows;

namespace latex_curriculum_vitae
{
    class Build
    {
        string tmpDir = Path.GetTempPath();        

        public Build()
        {
            string mytmpDir = Path.Combine(tmpDir, "latex_curriculum_vitae");
            Directory.CreateDirectory(mytmpDir);            
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string srcPath = Path.Combine(appDataPath, "latex_curriculum_vitae");

            // Letter of Application
            File.Copy(Path.Combine(srcPath, "Letter_of_Application", "letter_of_application.tex"), Path.Combine(mytmpDir, "letter_of_application.tex"));

            // Curriculum Vitae
            File.Copy(Path.Combine(srcPath, "Curriculum_Vitae", "curriculum_vitae.tex"), Path.Combine(mytmpDir, "curriculum_vitae.tex"));
            File.Copy(Path.Combine(srcPath, "Curriculum_Vitae", "friggeri-cv.cls"), Path.Combine(mytmpDir, "friggeri-cv.cls"));

            // Bibliography
            File.Copy(Path.Combine(srcPath, "Appendix", "Bibliography", "bibliography.bib"), Path.Combine(mytmpDir, "bibliography.bib"));


        }

        public string GetSubject(string subjectprefix, string jobtitle)
        {
            string subject = subjectprefix + " " + jobtitle;
            return subject;
        }

        public void CreateApplicationConfig(string jobtitle, string company, string contact, string street, string city, string salutation, string subject, string addressstring)
        {
            string[] lines = { "\\def\\jobtitle{" + jobtitle + "}", "\\def\\company{" + company + "}", "\\def\\contact{" + contact + "}", "\\def\\street{" + street + "}", "\\def\\city{" + city + "}", "\\def\\salutation{" + salutation + "}", "\\def\\subject{" + subject + "}", "\\def\\addressstring{" + addressstring + "}" };

            string mytmpDir = Path.Combine(tmpDir, "latex_curriculum_vitae");
            using StreamWriter outputFile = new StreamWriter(Path.Combine(mytmpDir, "application_details.tex"));
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }

        public void CompileApplication()
        {
            string mytmpDir = Path.Combine(tmpDir, "latex_curriculum_vitae");
            Directory.SetCurrentDirectory(mytmpDir);
            
            string[] strCmdText = { "/C pdflatex letter_of_application.tex", "/C xelatex curriculum_vitae.tex", "/C biber curriculum_vitae.bcf", "/C xelatex curriculum_vitae.tex" };
            
            foreach (string cmd in strCmdText)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = cmd;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }

        }

        public string GetFinalPdfName(string firstname, string familyname)
        {
            string finalpdf = "Bewerbungsunterlagen_" + firstname + "_" + familyname + ".pdf";
            return finalpdf;
        }

        public void CombineApplication(string firstname, string familyname)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string srcPath = Path.Combine(appDataPath, "latex_curriculum_vitae");
            string mytmpDir = Path.Combine(tmpDir, "latex_curriculum_vitae");
            Directory.SetCurrentDirectory(mytmpDir);

            string cos = "Certificates_Application_" + firstname + "_" + familyname + ".pdf";
            string cert = "Certificates_" + firstname + "_" + familyname + ".pdf";
            string finalpdf = GetFinalPdfName(firstname, familyname);

            string[] cosEntries = Directory.GetFiles(Path.Combine(srcPath, "Appendix", "Certificates_of_Employment"));
            string[] certEntries = Directory.GetFiles(Path.Combine(srcPath, "Appendix", "Certificates"));            
            string[] finalEntries = { "letter_of_application.pdf", "curriculum_vitae.pdf", cos, cert };            
            
            // Sort array in ascending order. 
            Array.Sort(cosEntries);

            // reverse array 
            Array.Reverse(cosEntries);

            // Sort array in ascending order. 
            Array.Sort(certEntries);

            // reverse array 
            Array.Reverse(certEntries);

            // Certificates of Employment
            MergePDFs(Path.Combine(mytmpDir, cos), cosEntries);

            // Certificates
            MergePDFs(Path.Combine(mytmpDir, cert), certEntries);


            // Production of the final document
            MergePDFs(Path.Combine(mytmpDir, finalpdf), finalEntries);
            
        }

        private void MergePDFs(string targetPath, params string[] pdfs)
        {
            using (PdfDocument targetDoc = new PdfDocument())
            {
                foreach (string pdf in pdfs)
                {
                    using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < pdfDoc.PageCount; i++)
                        {
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
                    }
                }
                targetDoc.Save(targetPath);
            }
        }

        public void OpenExplorer()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string _path = Path.Combine(path, "AppData", "Local", "Temp", "latex_curriculum_vitae");
            startInfo.Arguments = string.Format("/C start {0}", _path);
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
