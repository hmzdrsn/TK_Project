using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.ViewModel;

namespace TK_Project.Application.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordVM>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.newPassword1).Equal(y => y.newPassword2).WithMessage("Şifreniz Uyuşmuyor");
            RuleFor(x => x.newPassword1).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");
            RuleFor(x => x.oldPassword).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");
            RuleFor(x => x.newPassword2).NotEmpty().WithMessage("Şifre tekrar alanı boş bırakılamaz");
        }
    }
}
