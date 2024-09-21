using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace HotCatCafe.Common.ProductHelper
{
    public static class ProductOrderMail
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static void SendEmailToPurchase(string email, string mailBody)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");
            var emailContent = _configuration.GetSection("EmailContent");
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress(emailSettings["username"], emailSettings["displayName"]);
            sender.Subject = emailContent["subject"];
            sender.Body = mailBody;
            sender.To.Add(email);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(emailSettings["username"], emailSettings["password"]);
            smtpClient.Host = emailSettings["host"];
            smtpClient.Port = int.Parse(emailSettings["port"]);
            smtpClient.EnableSsl = true;
            smtpClient.Send(sender);
        }
    }
}
