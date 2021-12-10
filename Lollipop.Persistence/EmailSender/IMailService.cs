using System.Threading.Tasks;

namespace Lollipop.Persistence.EmailSender
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest mailRequest);
        public EmailRequest GenerateRecoveryEmail(string toEmail, string link);
        public EmailRequest GenerateRegistrationEmail(string toEmail, string link);
    }
}