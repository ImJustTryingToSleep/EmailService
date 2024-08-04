using EmailService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;
using EmailService.BLL.Logic.Contracts.Email;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly ILogger<EmailSenderController> _logger;
        private readonly IEmailSenderLogic _senderLogic;

        public EmailSenderController(
            ILogger<EmailSenderController> logger,
            IEmailSenderLogic senderLogic)
        {
            _logger = logger;
            _senderLogic = senderLogic;
        }

        // POST api/<EmailSenderController>
        [HttpPost("send")]
        public async Task Post([FromBody] EmailServiceMessage message)
        {
            await _senderLogic.SendEmailAsync(message);
        }
    }
}
