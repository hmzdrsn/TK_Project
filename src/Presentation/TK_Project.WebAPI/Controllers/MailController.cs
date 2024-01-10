using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Services;
using TK_Project.Domain.Entities;

namespace TK_Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("ReceiveAndSendMail")]
        public async Task<IActionResult> ReceiveAndSendMail()
        {
            await _mailService.ReceiveQueueAndSendMail();
            return Ok("calisti");
        }

        [HttpPost("SendMessageToQueue")]
        public async Task<IActionResult> SendMessageToQueue(Mail mail)
        {
            await _mailService.WriteQueue(mail);
            return Ok("Gonderildi");
        }

        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail(Mail mail)
        {
            await _mailService.SendMail(mail);
            return Ok("mail gönderildi");
        }

    }
}
