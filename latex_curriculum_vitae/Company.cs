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
    /// This class is for building a instance of the Company object.
    /// </summary>
    internal class Company
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }

        /// <summary>
        /// This Constructor sets the given arguments to this class Properties.
        /// </summary>
        /// <param name="coname">comes directly from gui txtCompanyName.Text (Contains companies name)</param>
        /// <param name="costreet">comes directly from the gui txtCompanyStreet.Text (Contains companies street)</param>
        /// <param name="czip">comes directly from the gui txtZIP.Text (Contains companies ZIP)</param>
        /// <param name="cocity">comes directly from the gui txtCity.Text (Contains companies city)</param>
        public Company(string coname, string costreet, string czip, string cocity)
        {
            Name = coname;
            Street = costreet;
            ZIP = czip;
            City = cocity;
        }

        /// <summary>
        /// This constructor will be used in case of we haven't a correct address for the company. It sets just the company name.
        /// </summary>
        /// <param name="coname">comes directly from gui txtCompanyName.Text (Contains companies name)</param>
        public Company(string coname)
        {
            Name = coname;
            Street = string.Empty;
            ZIP = string.Empty;
            City = string.Empty;
        }
    }
}
