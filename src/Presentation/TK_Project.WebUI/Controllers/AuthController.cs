using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TK_Project.Application.Interfaces.Repositories.Role;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.ViewModel;
using TK_Project.WebUI.Extensions;

namespace TK_Project.WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {

        readonly IUserReadRepository _userReadRepository;
        readonly IUserWriteRepository _userWriteRepository;
        readonly IRoleWriteRepository _roleWriteRepository;
        private IValidator<RegisterVM > _validatorRegister;
        public AuthController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IValidator<RegisterVM> validatorRegister, IRoleWriteRepository roleWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _validatorRegister = validatorRegister;
            _roleWriteRepository = roleWriteRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user =await _userReadRepository.GetUserByUsername(request.Username);
            
            if (user != null)
            {
                if(user.Username==request.Username && user.Password==request.Password)
                {
                    List<Claim> userClaims = new List<Claim>();
                    var userRoles = user.Roles.Select(x => x.Name).ToList();
                    userClaims.Add(new Claim(ClaimTypes.Name, user.Username));
                    foreach (var item in userRoles)
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role,item));
                    }
                    var claimsIdentity = new ClaimsIdentity(userClaims
                        ,CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("ProfileDetail", "Profile");
                }
            }
            else
            {
                //kullanici yok
            }

            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model, string ConfirmPassword)
        {
            var result = await _validatorRegister.ValidateAsync(model);
            
            if(result.IsValid)
            {
                if (model.Password == ConfirmPassword)
                {
                    List<int> roles = new List<int>();
                    roles.Add(2);
                    await _userWriteRepository.AddAsync(new Domain.Entities.User()
                    {
                        Username = model.Username,
                        Password = model.Password,
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        Mail = model.Mail,
                        Phone_Number = model.Phone_Number,
                    });

                    var userData = await _userReadRepository.GetUserByUsername(model.Username);
                    await _roleWriteRepository.AssignRole(userData.Id, roles);
                    return RedirectToAction("Login", "Auth");
                }
            }
            result.AddToModelState(this.ModelState);
            return View(model);
        }
        
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
