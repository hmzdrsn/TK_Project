using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.ViewModel;

namespace TK_Project.Application.Validators.UserValidators
{
    public class RegisterValidator : AbstractValidator<RegisterVM>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.First_Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Last_Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Phone_Number).NotEmpty().WithMessage("Bu alan boş bırakılamaz");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Mail Formatı Olmalıdır");

            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler uyuşmuyor");
            RuleFor(p => p.Password)
                    .MinimumLength(8).WithMessage("Şifreniz minimum 8 karakter olmalıdır")
                    .MaximumLength(16).WithMessage("Şifreniz maksimum 16 karakter olmalıdır")
                    .Matches(@"[A-Z]+").WithMessage("Şifreniz en az 1 büyük harf içermelidir.")
                    .Matches(@"[a-z]+").WithMessage("Şifreniz en az 1 küçük harf içermelidir.")
                    .Matches(@"[0-9]+").WithMessage("Şifreniz en az 1 sayı içermelidir.");

        }
    }
}
