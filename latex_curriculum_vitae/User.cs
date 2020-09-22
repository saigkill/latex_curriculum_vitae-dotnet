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
        private string _street;
        private string _city;
        private string _phone;
        private string _email;
        private string _blog;
        private string _subjectprefix;

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

        public User()
        {
            _firstname = ConfigurationManager.AppSettings.Get("firstname");
            _familyname = ConfigurationManager.AppSettings.Get("familyname");
            _street = ConfigurationManager.AppSettings.Get("mystreet");
            _city = ConfigurationManager.AppSettings.Get("mycity");
            _phone = ConfigurationManager.AppSettings.Get("myphone");
            _email = ConfigurationManager.AppSettings.Get("myemail");
            _blog = ConfigurationManager.AppSettings.Get("myblog");
            _subjectprefix = ConfigurationManager.AppSettings.Get("subject");
            
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
