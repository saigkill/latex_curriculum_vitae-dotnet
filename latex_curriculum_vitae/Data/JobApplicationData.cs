using System;
using System.Collections.Generic;
using System.Text;

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
