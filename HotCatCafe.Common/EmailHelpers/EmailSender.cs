using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace HotCatCafe.Common.EmailHelpers
{
    public static class EmailSender
    {
        private static IConfiguration _configuration;
        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static void SendEmail(string email, string subject, string body)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress(emailSettings["userName"], emailSettings["displayName"]);
            sender.Subject = subject;
            sender.Body = body;
            sender.To.Add(email);


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(emailSettings["userName"], emailSettings["password"]);
            smtpClient.Host =emailSettings["host"];
            smtpClient.Port = int.Parse(emailSettings["port"]);
            smtpClient.EnableSsl = true;

            smtpClient.Send(sender);
        }
    }
}
