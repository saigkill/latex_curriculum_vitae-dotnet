using System;
using System.Collections.Generic;
using System.Text;
using MimeKit.Utils;
using MimeKit;
using MailKit.Net.Smtp;
using System.IO;
using System.Windows;

namespace latex_curriculum_vitae
{
    class Email
    {
        public Email()
        {

        }

        public void CreateMessage(string firstname, string familyname, string myemail, string contactname, string compemail, string subject, string salutation, string attachment, string smtpserver, string smtpuser, string smtppass)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string lcvPath = Path.Combine(appDataPath, "latex_curriculum_vitae");
            string tmpDir = Path.GetTempPath();
            string mytmpDir = Path.Combine(tmpDir, "latex_curriculum_vitae");

            string myname = firstname + " " + familyname;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(myname, myemail));
            message.To.Add(new MailboxAddress(contactname, compemail));
            message.Bcc.Add(new MailboxAddress(myname, myemail));
            message.Subject = subject;
          

            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = string.Format(@"{0},

anbei sende ich Ihnen meine Bewerbungsunterlagen.

Mit freundlichem Gruß
Sascha Manns
", salutation);

            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.
            var image = builder.LinkedResources.Add(Path.Combine(lcvPath, "Pictures", "userpic.jpg"));
            image.ContentId = MimeUtils.GenerateMessageId();

            // Set the html version of the message text
            builder.HtmlBody = string.Format(@"<p>{0},<br>
<p>anbei sende ich Ihnen meine Bewerbungsunterlagen.<br>

<p align=left>Sascha Manns<br>
<center><img src=""cid:{1}"" width=""10%""></center></p>", salutation, image.ContentId);

            // We may also want to attach a calendar event for Monica's party...
            builder.Attachments.Add(Path.Combine(mytmpDir, attachment));

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();


            // Sending out
            using (var client = new SmtpClient())
            {
                client.Connect(smtpserver, 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(smtpuser, smtppass);

                client.Send(message);
                client.Disconnect(true);
            }

            MessageBox.Show("Your email is now sent. You can do the next job application.");
        }
    }
}
