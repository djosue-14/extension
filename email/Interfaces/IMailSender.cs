using System.Net.Mail;
using System.Threading.Tasks;
using email.Models;

namespace email.Interfaces
{
    public interface IMailSender
    {
        public SmtpClient Client { get; set; }
        
        public MailMessage MailMessage { get; set; }

        public void SmtpClient(string host, int port);

        public void Mail(Mail mail);
        
        public Task<bool> SendMailAsync();
        
        public bool SendMail();
    }
}