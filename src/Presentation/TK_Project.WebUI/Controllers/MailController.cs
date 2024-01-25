using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Services;

namespace TK_Project.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MailController : Controller
    {
        readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Domain.Entities.Mail mail)
        {
            await _mailService.WriteQueue(mail);
            await _mailService.ReceiveQueueAndSendMail();
            return View();
        }
        
    }
}
