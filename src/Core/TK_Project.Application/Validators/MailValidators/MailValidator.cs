using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.Validators.MailValidators
{
    public class MailValidator : AbstractValidator<Mail>
    {
        public MailValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject cannot be empty.");
            RuleFor(x => x.Body).NotEmpty().WithMessage("Message cannot be empty.");
            RuleFor(x => x.To).EmailAddress().WithMessage("Must Be Email Format");

        }
    }
}
