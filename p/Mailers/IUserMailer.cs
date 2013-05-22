using Mvc.Mailer;

namespace p.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
	}
}