using EmailService.Contracts;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.BLL.Logic.Contracts.Email
{
    public interface IEmailCreationLogic
    {
        MimeMessage CreateMail(EmailServiceMessage message);
    }
}
