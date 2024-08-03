using EmailService.BLL.Logic.Contracts.Email;
using EmailService.Contracts;
using MailKit;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.BLL.Logic.Email
{
    public class EmailCreationLogic : IEmailCreationLogic
    {
        private readonly ILogger<EmailCreationLogic> _logger;

        public EmailCreationLogic(ILogger<EmailCreationLogic> logger)
        {
            _logger = logger;
        }

        public MimeMessage CreateMail(EmailServiceMessage message)
        {
            try
            {
                var messageToSend = new MimeMessage();
                messageToSend.From.Add(new MailboxAddress(name: "Server", address: message.EmailFrom));
                messageToSend.To.Add(new MailboxAddress(name: "User", address: message.EmailTo));
                messageToSend.Subject = "УРА! УРА! УРА!";

                messageToSend.Body = new TextPart("plain")
                {
                    Text = message.MessageBody
                };

                _logger.LogInformation("Email was created");
                return messageToSend;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on creating an email");
                throw;
            }

        }
    }
}
