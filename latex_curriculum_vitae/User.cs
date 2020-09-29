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
        private string _firstname;
        private string _familyname;
        private readonly string _street;
        private readonly string _city;
        private readonly string _phone;
        private string _email;
        private readonly string _blog;
        private string _subjectprefix;
        private string _smtpserver;
        private string _smtpuser;
        private string _smtppass;
        private int _smtpport;

        public string Subject
        {
            get { return _subjectprefix; }
            set { _subjectprefix = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string Familyname
        {
            get { return _familyname; }
            set { _familyname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string SmtpServer
        {
            get { return _smtpserver; }
            set { _smtpserver = value; }
        }

        public string SmtpUser
        {
            get { return _smtpuser; ; }
            set { _smtpuser = value; }
        }

        public string SmtpPass
        {
            get { return _smtppass; }
            set { _smtppass = value; }
        }

        public int SmtpPort
        {
            get { return _smtpport; }
            set { _smtpport = value; }
        }

        public User()
        {            
            _firstname = Configuration.GetSetting("firstname");
            _familyname = Configuration.GetSetting("familyname");
            _street = Configuration.GetSetting("mystreet");
            _city = Configuration.GetSetting("mycity");
            _phone = Configuration.GetSetting("myphone");
            _email = Configuration.GetSetting("myemail");
            _blog = Configuration.GetSetting("myblog");
            _subjectprefix = Configuration.GetSetting("subject");
            _smtpserver = Configuration.GetSetting("smtp-server");
            _smtpuser = Configuration.GetSetting("smtp-user");
            _smtppass = Configuration.GetSetting("smtp-pass");
            _smtpport = Convert.ToInt32(Configuration.GetSetting("smtp-port"));

            UserFile();
        }

        private void UserFile()
        {
            string[] lines = { "\\def\\firstname{" + _firstname + "}", "\\def\\familyname{" + _familyname + "}" , "\\def\\mystreet{" + _street + "}", "\\def\\mycity{" + _city + "}", "\\def\\myphone{" + _phone + "}", "\\def\\myemail{" + _email + "}", "\\def\\myblog{" + _blog + "}" };

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
