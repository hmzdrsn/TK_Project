using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Auth;
using TK_Project.Application.ViewModel;

namespace TK_Project.WebUI.Controllers
{
    public class LoginController : Controller
    {
        readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            return RedirectToAction("Index", "Profile",result);
        }
    }
}
