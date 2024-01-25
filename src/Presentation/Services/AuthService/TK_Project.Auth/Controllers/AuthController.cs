using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Auth;
using TK_Project.Application.ViewModel;

namespace TK_Project.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;
        readonly IValidator<LoginRequest> _loginValidator;
        readonly IValidator<RegisterVM> _registerValidator;
        public AuthController(IAuthService authService, IValidator<LoginRequest> loginValidator, IValidator<RegisterVM> registerValidator)
        {
            _authService = authService;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginRequest request)
        {
            var result = await _loginValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                var response = await _authService.LoginAsync(request);
                return response;
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            var result = await _registerValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                await _authService.RegisterAsync(model);
                return Ok("successfully registered");
            }
            return BadRequest(result.Errors);
        }

        //[HttpPost("SignOut")]
        //[Authorize]
        //public async Task<IActionResult> SignOutAsync()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        await HttpContext.SignOutAsync();
        //        return Ok("exited");
        //    }
        //    return BadRequest("no authorize");
        //}
    }
}
