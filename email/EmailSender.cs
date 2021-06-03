using System;
using System.Net.Mail;
using System.Threading.Tasks;
using email.Models;
using email.Interfaces;
using Address = System.Net.Mail.MailAddress;

namespace email
{
    public class EmailSender : IMailSender
    {
        /// <summary>
        /// SMTP Client
        /// </summary>
        public SmtpClient Client { get; set; }
        
        /// <summary>
        /// Mail Message
        /// </summary>
        public MailMessage MailMessage { get; set; }

        /// <summary>
        /// Create Client to connect to SMTP Server
        /// </summary>
        /// <param name="host">SMTP Server</param>
        /// <param name="port">SMTP Server Port to Connect</param>
        /// <exception cref="ArgumentException">SMTP Server Host not found in request</exception>
        public void SmtpClient(string host, int port)
        {
            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentException("SMTP Host not found", nameof(host));
            }

            Client = new SmtpClient()
            {
                Host = host,
                Port = port
            };
        }

        /// <summary>
        /// Configure a Mail Message to send
        /// </summary>
        /// <param name="mail">Model to Configure a Mail Message</param>
        /// <exception cref="ArgumentException">Mail Message arguments not found in request</exception>
        public void Mail(Mail mail)
        {
            //Valida si existe la dirección de origen.
            if (string.IsNullOrEmpty(mail.From))
            {
                throw new ArgumentException("Mail Address From not found", nameof(mail.From));
            }

            //Valida si existe una o más direcciones de destino.
            if (mail.To == null || mail.To.Count == 0)
            {
                throw new ArgumentException("Mail Addresses To not found", nameof(mail.To));
            }

            //Valida si existe un Asunto.
            if (string.IsNullOrEmpty(mail.Subject))
            {
                throw new ArgumentException("Subject not found", nameof(mail.Subject));
            }

            //Se agregan las configuraciones del Correo Electrónico.
            MailMessage = new MailMessage
            {
                From = new Address(mail.From),
                Subject = mail.Subject,
                Body = mail.Body,
                IsBodyHtml = true,
                Priority = MailPriority.Normal
            };

            //Se agregan los destinatarios.
            mail.To.ForEach(item => MailMessage.To.Add(item.Address));

            //Se agregan las direcciones CC
            mail.Cc?.ForEach(item => MailMessage.CC.Add(item.Address));

            //Se agregan las direcciones BCC
            mail.Bcc?.ForEach(item => MailMessage.Bcc.Add(item.Address));
        }

        /// <summary>
        /// Send an asynchronous mail message to mail addresses
        /// </summary>
        /// <returns>true if the email has been sent or false if the email has not been sent</returns>
        public async Task<bool> SendMailAsync()
        {
            try
            {
                Convert.ToBoolean(null);
                await Client.SendMailAsync(MailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Send an mail message to mail addresses
        /// </summary>
        /// <returns>true if the email has been sent or false if the email has not been sent</returns>
        public bool SendMail()
        {
            try
            {
                Client.Send(MailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}