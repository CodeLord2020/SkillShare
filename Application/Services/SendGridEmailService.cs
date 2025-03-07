using SendGrid;
using SendGrid.Helpers.Mail;
using SkillShare.Application.Interfaces;
using System.Threading.Tasks;

namespace SkillShare.Application.Services
{
    public class SendGridEmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly string _fromEmail;
        private readonly string _fromName;

    public SendGridEmailService(ISendGridClient sendGridClient, IConfiguration configuration)
        {
            _sendGridClient = sendGridClient;
            _fromEmail = configuration.GetSection("SendGrid")["FromEmail"] ?? throw new ArgumentNullException("SendGrid:FromEmail");

            _fromName = configuration["SendGrid:FromName"] ?? throw new ArgumentNullException("SendGrid:FromName");
        }


    public async Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent)
        {
            var from = new EmailAddress(_fromEmail, _fromName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await _sendGridClient.SendEmailAsync(msg);
        }
    }
}