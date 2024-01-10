using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.ViewModel;

namespace TK_Project.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index(LoginResponse response)
        {
            return View(response);
        }
    }
}
