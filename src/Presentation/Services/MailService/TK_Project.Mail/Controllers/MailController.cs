using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Services;

namespace TK_Project.Mail.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class MailController : Controller
    {
        private readonly IMailService _mailService;
        private IValidator<Domain.Entities.Mail> _mailValidator;
        public MailController(IMailService mailService, IValidator<Domain.Entities.Mail> mailValidator)
        {
            _mailService = mailService;
            _mailValidator = mailValidator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("ReceiveAndSendMail")]
        public async Task<IActionResult> ReceiveAndSendMail()
        {
            await _mailService.ReceiveQueueAndSendMail();
            return Ok("emails sent successfully");
        }
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("SendMessageToQueue")]
        public async Task<IActionResult> SendMessageToQueue([FromBody] Domain.Entities.Mail mail)
        {
            var result = await _mailValidator.ValidateAsync(mail);
            if (result.IsValid)
            {
                await _mailService.WriteQueue(mail);
                return Ok("Writed Queue");
            }
            return BadRequest(result.Errors);
        }
        [Authorize(Roles = "Admin,Member")]
        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail(Domain.Entities.Mail mail)
        {
            var result = await _mailValidator.ValidateAsync(mail);
            if (result.IsValid)
            {
                await _mailService.SendMail(mail);
                return Ok("mail sent successfully");
            }
            return BadRequest(result.Errors);
        }
    }
}
