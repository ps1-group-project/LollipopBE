using System.Threading.Tasks;

namespace Lollipop.Persistence.EmailSender
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest mailRequest);
    }
}