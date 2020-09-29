using System;
using System.Collections.Generic;
using System.Text;

namespace latex_curriculum_vitae
{
    class Company
    {
        private string _name;
        private string _street;
        private int _zip;
        private string _city;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public int ZIP
        {
            get { return _zip; }
            set { _zip = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }


        public Company(string coname, string costreet, int czip, string cocity)
        {
            Name = coname;
            Street = costreet;
            ZIP = czip;
            City = cocity;
        }

        public Company(string coname)
        {
            Name = coname;
            Street = "";
            ZIP = 0;
            City = "";
        }        
    }
}
