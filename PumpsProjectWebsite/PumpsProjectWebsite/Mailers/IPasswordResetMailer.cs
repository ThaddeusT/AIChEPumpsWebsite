using Mvc.Mailer;
using PumpsProjectWebsite.Mailers.Models;

namespace PumpsProjectWebsite.Mailers
{ 
    public interface IPasswordResetMailer
    {
			MvcMailMessage PasswordReset(MailerModel model);
	}
}