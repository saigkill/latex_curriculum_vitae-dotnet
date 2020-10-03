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

namespace latex_curriculum_vitae.Data
{
    public class JobApplicationData
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Jobtitle { get; set; }
        public string City { get; set; }
        public string ContactName { get; set; }
        public string Status { get; set; }
        public DateTime EmailSent { get; set; }
        public DateTime EmailConfirmation { get; set; }
        public DateTime LastPhonecall { get; set; }
        public DateTime JobInterview { get; set; }
        public string JobOfferUrl { get; set; }
    }
}
