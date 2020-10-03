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

namespace latex_curriculum_vitae
{
    /// <summary>
    /// This class is for instancing a Contact object.
    /// </summary>
    class Contact
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public string Salutation { get; set; }

        /// <summary>
        /// This Constructor sets the arguments values to the Properties and instances the object.
        /// </summary>
        /// <param name="cname">comes from the gui txtContactName.Text (Contains the name of the contact)</param>
        /// <param name="gname">comes from the gui (Contains the contacts gender)</param>
        public Contact(string cname, string gname)
        {
            Name = cname;
            Gender = gname;

            Salutation = GetSalutation(Name, Gender);
        }

        /// <summary>
        /// This method creates from the contact name and gender the right salutation. Ex. Dear Mr. Manns
        /// </summary>
        /// <param name="cname">comes from the gui txtContactName.Text (Contains the name of the contact)</param>
        /// <param name="gname">comes from the gui (Contains the contacts gender)</param>
        /// <returns>string salutation</returns>
        private string GetSalutation(string cname, string gname)
        {
            string salutation;

            if (gname == "Male")
            {
                salutation = "Sehr geehrter Herr " + cname + ",";
            }
            else if (gname == "Female")
            {
                salutation = "Sehr geehrte Frau " + cname + ",";
            }
            else
            {
                salutation = "Sehr geehrte Damen und Herren,";
            }
            return salutation;
        }

        /// <summary>
        /// This method combines the arguments to create a address string for using in the letter of application.
        /// </summary>
        /// <param name="company">comes from company.Name (Contains the company name)</param>
        /// <param name="contactname">comes from contact.Name (Contains the contact name)</param>
        /// <param name="cgender">comes from contact.Gender (Contains contacts gender)</param>
        /// <param name="cstreet">comes from company.Street (Contains companies street)</param>
        /// <param name="ccity">comes from company.City (Contains companies city)</param>
        /// <returns>string addressline</returns>
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
