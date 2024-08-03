using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using EmailService;

namespace NetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            SendEmailAsync(new EmailServiceMessage()).GetAwaiter();
            Console.Read();
        }

        private static async Task SendEmailAsync(EmailServiceMessage message)
        {
            MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
            MailAddress to = new MailAddress("somemail@yandex.ru");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "Письмо-тест 2 работы smtp-клиента";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
            Console.WriteLine("Письмо отправлено");
        }
    }
}