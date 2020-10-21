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
using System.IO;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// This class instances the User object.
    /// </summary>
    class User
    {
        public string Firstname { get; set; }

        public string Familyname { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Blog { get; set; }

        public string SmtpServer { set; get; }

        public string SmtpUser { set; get; }

        public string SmtpPass { set; get; }

        public int SmtpPort { set; get; }

        public string BitLyToken { get; set; }

        /// <summary>
        /// That constructor uses the config file to set up all user relevant information.
        /// </summary>
        public User()
        {
            Firstname = Configuration.GetSetting("firstname");
            Familyname = Configuration.GetSetting("familyname");
            Street = Configuration.GetSetting("mystreet");
            City = Configuration.GetSetting("mycity");
            Phone = Configuration.GetSetting("myphone");
            Email = Configuration.GetSetting("myemail");
            Blog = Configuration.GetSetting("myblog");
            SmtpServer = Configuration.GetSetting("smtp-server");
            SmtpUser = Configuration.GetSetting("smtp-user");
            SmtpPass = Configuration.GetSetting("smtp-pass");
            SmtpPort = Convert.ToInt32(Configuration.GetSetting("smtp-port"));
            BitLyToken = Configuration.GetSetting("bitly-token");

            UserFile();
        }

        /// <summary>
        /// This method uses the information from the Properties to create the LaTEX user configuration file "personal_data.tex" what will be used by letter of application and also for curriculum_vitae.
        /// </summary>
        private void UserFile()
        {
            string[] lines = { "\\def\\firstname{" + Firstname + "}", "\\def\\familyname{" + Familyname + "}", "\\def\\mystreet{" + Street + "}", "\\def\\mycity{" + City + "}", "\\def\\myphone{" + Phone + "}", "\\def\\myemail{" + Email + "}", "\\def\\myblog{" + Blog + "}" };

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
