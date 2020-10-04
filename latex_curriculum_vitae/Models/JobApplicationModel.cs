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

using CsvHelper.Configuration.Attributes;
using System;

namespace latex_curriculum_vitae.Models
{
    public class JobApplicationModel
    {
        [Name(Constants.CsvHeaders.Company)]
        public string Company { get; set; }
        [Name(Constants.CsvHeaders.Jobtitle)]
        public string Jobtitle { get; set; }
        [Name(Constants.CsvHeaders.City)]
        public string City { get; set; }
        [Name(Constants.CsvHeaders.Status)]
        public string Status { get; set; }
        [Name(Constants.CsvHeaders.EmailSent)]
        public DateTime EmailSent { get; set; }
        [Name(Constants.CsvHeaders.JobOfferUrl)]
        public string JobOfferUrl { get; set; }
    }
}
