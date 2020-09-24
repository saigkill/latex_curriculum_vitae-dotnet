using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Text;
using System.Windows;

namespace latex_curriculum_vitae
{
    class Contact
    {
        private string _name;
        private string _gender;
        private string _salutation;        

        public string Name   
        {
            get { return _name; } 
            set { _name = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Salutation
        {
            get { return _salutation; }
            set { _salutation = value; }
        }       

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
            addressline = company + "\\\\";
            if (contactname == "" || cgender == "Unknown")
            {
                addressline = addressline + "Personalabteilung \\\\";
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
                addressline = addressline + ccity;
            }

            return addressline;
        }
    }
}
