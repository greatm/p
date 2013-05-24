using Mvc.Mailer;

namespace p.Mailers
{
    public class UserMailer : MailerBase, IUserMailer
    {
        public UserMailer()
        {
            MasterName = "_Layout";
        }

        public virtual MvcMailMessage MailMessage(string mailMessage)
        {
            return Populate(x =>
            {
                x.To.Add("manoj.great@hotmail.com");
                x.Subject = "mail from p mvc app";
                x.Body = mailMessage;
                x.ViewName = "Welcome";
            });
        }
        public virtual MvcMailMessage Welcome()
        {
            //ViewBag.Data = someObject;
            return Populate(x =>
            {
                x.Subject = "mail from p mvc app";
                x.ViewName = "Welcome";
                x.To.Add("manoj.great@hotmail.com");
            });
        }
    }
}