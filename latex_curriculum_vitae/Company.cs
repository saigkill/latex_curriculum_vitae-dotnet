using System;
using System.Collections.Generic;
using System.Text;

namespace latex_curriculum_vitae
{
    class Company
    {                                
        public string Name { get; set; }
        public string Street { get; set; }
        public int ZIP { get; set; }        
        public string City { get; set; }        


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
