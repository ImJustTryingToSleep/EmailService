using EmailService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.BLL.Logic.Contracts.Email
{
    public interface IEmailSenderLogic
    {
        Task SendEmailAsync(EmailServiceMessage message);
    }
}
