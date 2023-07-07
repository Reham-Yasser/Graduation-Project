using DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace Edu_Chatbot.Helper
{
    public class EmailSettings
    {

        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.sendgrid.net", 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("apikey", "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");
            Client.Send("kaljmal455@gmail.com", email.To, email.Title, email.Body);

        }

    }
}
