using System.Threading.Tasks;

namespace JWS.Mail
{
	public interface IMailService
	{
		Task<bool> SendAsync(MailMessage mailMessage, bool keepReceiver = false);
	}
}
