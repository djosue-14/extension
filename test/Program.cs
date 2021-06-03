using System;
using System.Collections.Generic;
using System.Net.Mail;
using email;
using email.Interfaces;
using email.Models;
using MailAddress = email.Models.MailAddress;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMailSender sender = new EmailSender();
            //
            // sender.SmtpClient("exfha", 25);
            //
            // var model = new Mail()
            // {
            //     From = "sistema_notificaciones@fha.gob.gt",
            //     To = new List<MailAddress>
            //     {
            //         new MailAddress {Address = "kevin_ramos@fha.gob.gt"}
            //     },
            //     Cc = new List<MailAddress>
            //     {
            //         new MailAddress {Address = "darwinj_hernandez@fha.gob.gt"}
            //     },
            //     Subject = "FHA Mails",
            //     Body = "<h1>Hola Mundo :D</h1>"
            // };
            //
            // sender.Mail(model);
            // var result = sender.SendMailAsync().Result;
            //
            // Console.WriteLine(result.ToString());
            Console.WriteLine("Hello World!");
        }
    }
}
