using EmailService.BLL.Logic.Contracts.Email;
using EmailService.Entities;
using MimeKit;
//using System.Net.Mail;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmailService.BLL.Logic.Email
{
    public class EmailSenderLogic : IEmailSenderLogic
    {
        private readonly IEmailCreationLogic _emailCreationLogic;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailCreationLogic> _logger;

        public EmailSenderLogic(
            IEmailCreationLogic emailCreationLogic,
            IConfiguration configuration,
            ILogger<EmailCreationLogic> logger
            )
        {
            _emailCreationLogic = emailCreationLogic;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task SendEmailAsync(EmailServiceMessage message)
        {
            try
            {
                var messageToSend = _emailCreationLogic.CreateMail(message);

                using (var client = new SmtpClient())
                {
                    client.Connect(host: _configuration["ConnectionToMailSettings:host"], 
                        port: int.Parse(_configuration["ConnectionToMailSettings:Port"]!), useSsl: true);
                    client.Authenticate(userName: _configuration["ConnectionToMailSettings:MailName"], password: _configuration["ConnectionToMailSettings:Password"]);
                    client.Send(messageToSend);
                    client.Disconnect(quit: true);
                }
                _logger.LogInformation("Email was sended from {MessageFrom} to {MessageTo}", message.EmailFrom, message.EmailTo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in time of sending message");
            }
        }
    }
}
