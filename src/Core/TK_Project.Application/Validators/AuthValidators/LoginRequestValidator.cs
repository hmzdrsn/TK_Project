using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.ViewModel;

namespace TK_Project.Application.Validators.AuthValidators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
             RuleFor(x=>x.Username).NotEmpty().WithMessage("Kullanıcı adı giriniz");
             RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifrenizi Giriniz");
        }
    }
}
