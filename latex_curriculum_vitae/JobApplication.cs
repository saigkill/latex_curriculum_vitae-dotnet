using System;
using System.Collections.Generic;
using System.Text;

namespace latex_curriculum_vitae
{
    class JobApplication
    {
        private string _url;
        private string _email;
        private string _jobtitle;

        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Jobtitle
        {
            get { return _jobtitle; }
            set { _jobtitle = value; }
        }        

        public JobApplication(string aurl, string aemail, string ajobtitle)
        {
            URL = aurl;
            Email = aemail;
            Jobtitle = ajobtitle;            
        }
    }
}
