using EMS.Business;
using MailKit.Net.Smtp;
using MimeKit;

namespace exams_management_system
{
    public class SMTPClient
    {
        public static void SendMail(StudentDetailsModel studentDetailsModel)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Random student", "ergfdfgsgasdfasd@gmail.com"));
            message.To.Add(new MailboxAddress("Gorgan Gabriel", "gabigorgan@gmail.com"));
            message.Subject = "Constestatie";

            var emailText = @"Buna ziua,
                Ma numesc " + studentDetailsModel.Name +
                " si sunt in grupa "    + studentDetailsModel.Group +
                @".  As dori sa fac contestatie.
               
                -Multumesc!";
            message.Body = new TextPart("plain")
            {
                Text = emailText
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("ergfdfgsgasdfasd@gmail.com", "mypassword.notsarcastic");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}