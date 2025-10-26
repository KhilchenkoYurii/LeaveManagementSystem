using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagementSystem.Web.Services.Email
{
    public class EmailSender(IConfiguration _configuration) : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromAddress = _configuration["Email:DefaultEmailAddress"];
            var smtpServer = _configuration["Email:Server"];
            var smtpPort = _configuration["Email:Port"];

            var message = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email));

            using (var client = new SmtpClient(smtpServer,int.Parse(smtpPort)))
            {
                await client.SendMailAsync(message);
            }
        }
    }
}
