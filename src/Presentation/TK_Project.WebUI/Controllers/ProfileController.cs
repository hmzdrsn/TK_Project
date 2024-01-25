using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.WebUI.Extensions;
using TK_Project.WebUI.Models;

namespace TK_Project.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private IValidator<Application.ViewModel.ChangePasswordVM> _changePasswordValidator;
        public ProfileController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IValidator<Application.ViewModel.ChangePasswordVM> changePasswordValidator)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _changePasswordValidator = changePasswordValidator;
        }

        public async Task<IActionResult> ProfileDetail()
        {

            var authType = User.Identity.AuthenticationType;
            if (User.Identity.IsAuthenticated)

            {
                var roles= User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
                foreach (var item in roles)
                {
                    ViewBag.Roles+= item;
                }
                var data = await _userReadRepository
                .GetUserByUsername(User.Identity.Name);

                return View(new UpdateProfileVM()
                {
                    Username= data.Username,
                    First_Name = data.First_Name,
                    Last_Name = data.Last_Name,
                    Mail = data.Mail,
                    Address = data.Address,
                    Phone_Number = data.Phone_Number,
                    ImageUrl = data.ImageUrl
                });
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateProfileVM model)
        {
            var user = await _userReadRepository.GetUserByUsername(model.Username);
            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/Images/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await model.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }
            user.First_Name = model.First_Name;
            user.Last_Name = model.Last_Name;
            user.Mail = model.Mail;
            user.Address = model.Address;
            user.Phone_Number = model.Phone_Number;
            await _userWriteRepository.UpdateAsync(user);
            return RedirectToAction("ProfileDetail", "Profile");
        }

        [HttpGet]
        public IActionResult UpdatePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(Application.ViewModel.ChangePasswordVM model)
        {
            
            var result = await _changePasswordValidator.ValidateAsync(model);
            
            if (result.IsValid)
            {
                if (model.newPassword1 == model.newPassword2)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var data = await _userReadRepository
                        .GetUserByUsername(User.Identity.Name);
                        if (data.Password != model.oldPassword)
                        {
                            //yanlis sifre
                        }
                        else if (data.Password == model.oldPassword)
                        {
                            data.Password = model.newPassword1;
                            await _userWriteRepository.UpdateAsync(data);
                            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                            return RedirectToAction("Auth", "Login");
                        }
                    }
                }

            }
            
            result.AddToModelState(this.ModelState);
            
            return View(model);
        }

    }
}
