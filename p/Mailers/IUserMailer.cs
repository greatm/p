using Mvc.Mailer;

namespace p.Mailers
{
    public interface IUserMailer
    {
        MvcMailMessage Welcome();
        MvcMailMessage MailMessage(string mailMessage);
    }
}