using MailKit.Net.Smtp;
using MimeKit;

namespace exams_management_system
{
    public class SMTPClient
    {
        public static void SendMail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Random student", "ergfdfgsgasdfasd@gmail.com"));
            message.To.Add(new MailboxAddress("Gorgan Gabriel", "gabigorgan@gmail.com"));
            message.Subject = "Constestatie";

            message.Body = new TextPart("plain")
            {
                Text = @"Buna ziua,

                As dori sa fac contestatie.

                -Multumesc!"
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("ergfdfgsgasdfasd@gmail.com", "CodeMaster1");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}