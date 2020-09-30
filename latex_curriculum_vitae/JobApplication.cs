using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace latex_curriculum_vitae
{
    class JobApplication
    {        
        public string URL { get; set; }        
        public string Email { get; set; }        
        public string Jobtitle { get; set; }        

        public JobApplication(string aurl, string aemail, string ajobtitle)
        {
            URL = aurl;
            Email = aemail;
            Jobtitle = FixJobApplication(ajobtitle);
        }

        public string FixJobApplication(string ajobtitle)
        {
            string _prepare = ajobtitle;            
            _prepare = _prepare.Replace(@"#", @"\#");
            _prepare = _prepare.Replace(@"&", @"\&");
            return _prepare;
        }
    }
}
