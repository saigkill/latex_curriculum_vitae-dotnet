namespace latex_curriculum_vitae.Models
{
    public class EmailModel
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string MyEmail { get; set; }
        public string ContactName { get; set; }
        public string CompEmail { get; set; }
        public string Subject { get; set; }
        public string Salutation { get; set; }
        public string Attachment { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public int SmtpPort { get; set; }
    }
}
