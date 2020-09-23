using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using Spire.Pdf;
using Spire.Pdf.Graphics;
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

        public void CreateApplicationConfig(string jobtitle, string company, string contact, string street, string city, string salutation, string subjectprefix, string addressstring)
        {
            string[] lines = { "\\def\\jobtitle{" + jobtitle + "}", "\\def\\company{" + company + "}", "\\def\\contact{" + contact + "}", "\\def\\street{" + street + "}", "\\def\\city{" + city + "}", "\\def\\salutation{" + salutation + "}", "\\def\\subject{" + subjectprefix + " " + jobtitle + "}", "\\def\\addressstring{" + addressstring + "}" };

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

        public void CombineApplication(string firstname, string familyname)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string srcPath = Path.Combine(appDataPath, "latex_curriculum_vitae");
            string mytmpDir = Path.Combine(tmpDir, "latex_curriculum_vitae");
            Directory.SetCurrentDirectory(mytmpDir);

            string cos = "Certificates_Application_" + firstname + "_" + familyname + ".pdf";
            string cert = "Certificates_" + firstname + "_" + familyname + ".pdf";
            string finalpdf = "Bewerbungsunterlagen_" + firstname + "_" + familyname + ".pdf";

            string[] cosEntries = Directory.GetFiles(Path.Combine(srcPath, "Appendix", "Certificates_of_Employment"));
            string[] certEntries = Directory.GetFiles(Path.Combine(srcPath, "Appendix", "Certificates"));            
            string[] final = { "letter_of_application.pdf", "curriculum_vitae.pdf", cos, cert };            
            
            // Sort array in ascending order. 
            Array.Sort(cosEntries);

            // reverse array 
            Array.Reverse(cosEntries);

            // Sort array in ascending order. 
            Array.Sort(certEntries);

            // reverse array 
            Array.Reverse(certEntries);

            // Certificates of Employment
            //open pdf documents                                 
            PdfDocument[] docs = new PdfDocument[cosEntries.Length];
            for (int i = 0; i < cosEntries.Length; i++)
            {
                docs[i] = new PdfDocument(cosEntries[i]);
            }
            //append document
            docs[0].AppendPage(docs[1]);
            //import pages
            for (int i = 0; i < docs[2].Pages.Count; i = i + 2)
            {
                docs[0].InsertPage(docs[2], i);
            }
            docs[0].SaveToFile(cos);
            foreach (PdfDocument doc in docs)
            {
                doc.Close();
            }
            
            // Certificates
            //open pdf documents           
            PdfDocument[] docs1 = new PdfDocument[certEntries.Length];
            for (int i = 0; i < certEntries.Length; i++)
            {
                docs1[i] = new PdfDocument(certEntries[i]);
            }
            //append document
            docs1[0].AppendPage(docs1[1]);
            //import pages
            for (int i = 0; i < docs1[2].Pages.Count; i = i + 2)
            {
                docs1[0].InsertPage(docs1[2], i);
            }
            docs1[0].SaveToFile(cert);
            foreach (PdfDocument doc in docs1)
            {
                doc.Close();
            }            

            // Production of the final document
            //open pdf documents           
            PdfDocument[] docs2 = new PdfDocument[final.Length];
            for (int i = 0; i < final.Length; i++)
            {
                docs2[i] = new PdfDocument(final[i]);
            }
            //append document
            docs2[0].AppendPage(docs2[1]);
            //import pages
            for (int i = 0; i < docs2[2].Pages.Count; i = i + 2)
            {
                docs2[0].InsertPage(docs2[2], i);
            }
            docs2[0].SaveToFile(finalpdf);
            foreach (PdfDocument doc in docs2)
            {
                doc.Close();
            }            
        }        
    }
}
