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

using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using System;
using System.IO;
using System.Windows;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// This class is for creating and sending job applications via email
    /// </summary>
    public static class Email
    {
        /// <summary>
        /// This is the main method for creating and sending emails. It doesn't returns anything.        
        /// </summary>
        /// <param name="firstname">comes from myuser.Firstname</param>
        /// <param name="familyname">comes from myuser.Familyname</param>
        /// <param name="myemail">comes from myuser.Email</param>
        /// <param name="contactname">comes from contact.Name</param>
        /// <param name="compemail">comes from myapplication.Email</param>
        /// <param name="subject">comes originally from Build.GetEmailSubject</param>
        /// <param name="salutation">comes from contact.Salutation</param>
        /// <param name="attachment">comes from Build.GetFinalPdfName</param>
        /// <param name="smtpserver">comes from myuser.SmtpServer</param>
        /// <param name="smtpuser">comes from myuser.SmtpUser</param>
        /// <param name="smtppass">comes from myuser.SmtpPass</param>
        /// <param name="smtpport">myuser.SmtpPort</param>
        public static void CreateMessage(string firstname, string familyname, string myemail, string contactname, string compemail, string subject, string salutation, string attachment, string smtpserver, string smtpuser, string smtppass, int smtpport)
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

            BodyBuilder builder = new BodyBuilder
            {
                // Set the plain-text version of the message text
                TextBody = string.Format(@Properties.Resources.EmailPlain, salutation, myname)
            };

            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.
            var image = builder.LinkedResources.Add(Path.Combine(lcvPath, "Pictures", "userpic.jpg"));
            image.ContentId = MimeUtils.GenerateMessageId();

            // Set the html version of the message text
            builder.HtmlBody = string.Format(@Properties.Resources.EmailHTML, salutation, myname, image.ContentId);

            // We may also want to attach a calendar event for Monica's party...
            builder.Attachments.Add(Path.Combine(mytmpDir, attachment));

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();

            if (smtpserver == "" || smtpport.ToString() == "" || smtpuser == "" || smtppass == "")
            {
                MessageBox.Show(Properties.Resources.EmailNotSet, Properties.Resources.EmailNotSetHeader, MessageBoxButton.OK, MessageBoxImage.Error);
                Window settings = new UserSettingsWindow();
                settings.Show();
            }
            else
            {
                // Sending out
                using var client = new SmtpClient();
                client.Connect(smtpserver, smtpport, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(smtpuser, smtppass);

                client.Send(message);
                client.Disconnect(true);
            }

            MessageBox.Show(Properties.Resources.MsgEmailSent, Properties.Resources.MsgHeaderInfo);
        }
    }
}
