using System;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace latex_curriculum_vitae
{
    class User
    {        
        public string Subject { get; set; }        

        public string Firstname { get; set; }        

        public string Familyname { get; set; }
        
        public string Street { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }        

        public string Blog { get; set; }

        public string Subjectprefix { get; set; }

        public string SmtpServer { set; get; }        

        public string SmtpUser { set; get; }        

        public string SmtpPass { set; get; }        

        public int SmtpPort { set; get; }        

        public User()
        {            
            Firstname = Configuration.GetSetting("firstname");
            Familyname = Configuration.GetSetting("familyname");
            Street = Configuration.GetSetting("mystreet");
            City = Configuration.GetSetting("mycity");
            Phone = Configuration.GetSetting("myphone");
            Email = Configuration.GetSetting("myemail");
            Blog = Configuration.GetSetting("myblog");
            Subjectprefix = Configuration.GetSetting("subject");
            SmtpServer = Configuration.GetSetting("smtp-server");
            SmtpUser = Configuration.GetSetting("smtp-user");
            SmtpPass = Configuration.GetSetting("smtp-pass");
            SmtpPort = Convert.ToInt32(Configuration.GetSetting("smtp-port"));

            UserFile();
        }

        private void UserFile()
        {
            string[] lines = { "\\def\\firstname{" + Firstname + "}", "\\def\\familyname{" + Familyname + "}" , "\\def\\mystreet{" + Street + "}", "\\def\\mycity{" + City + "}", "\\def\\myphone{" + Phone + "}", "\\def\\myemail{" + Email + "}", "\\def\\myblog{" + Blog + "}" };

            // Set a variable to the Documents path.
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string lcvDataPath = Path.Combine(appDataPath, "latex_curriculum_vitae");
            Directory.CreateDirectory(lcvDataPath);

            // Write the string array to a new file named "WriteLines.txt".
            using StreamWriter outputFile = new StreamWriter(Path.Combine(lcvDataPath, "personal_data.tex"));
            foreach (string line in lines)
                outputFile.WriteLine(line);

        }        

    }
}
