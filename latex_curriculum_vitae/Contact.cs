using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Text;
using System.Windows;

namespace latex_curriculum_vitae
{
    class Contact
    {        
        public string Name { get; set; }        

        public string Gender { get; set; }        

        public string Salutation { get; set; }         

        public Contact(string cname, string gname)
        {
            Name = cname;
            Gender = gname;

            Salutation = GetSalutation(Name, Gender);           
        }

        private string GetSalutation(string cname, string gname)
        {
            string salutation;
            
            if (gname == "Male")
            {
                salutation = "Sehr geehrter Herr " + cname + ",";
            }
            else if (gname == "Female") {
                salutation = "Sehr geehrte Frau " + cname + ",";
            }
            else
            {
                salutation = "Sehr geehrte Damen und Herren,";
            }
            return salutation;
        }

        public string Addressline(string company, string contactname, string cgender, string cstreet, string ccity)
        {
            string addressline;
            company = company.Replace(@"#", @"\#");
            company = company.Replace(@"&", @"\&");

            addressline = company + "\\\\";
            if (contactname == "" || cgender == "Unknown")
            {
                addressline += "Personalabteilung \\\\";
            }
            else
            {
                if (cgender == "Male")
                {
                    addressline = addressline + "Herrn " + contactname + "\\\\";
                }
                else
                {
                    addressline = addressline + "Frau " + contactname + "\\\\";
                }
            }

            if (cstreet != "")
            {
                addressline = addressline + cstreet + "\\\\";
            }

            if (ccity != "")
            {
                addressline += ccity;
            }

            return addressline;
        }
    }
}
