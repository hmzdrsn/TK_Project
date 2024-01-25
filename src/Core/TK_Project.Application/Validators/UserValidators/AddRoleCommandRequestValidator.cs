using FluentValidation;
using TK_Project.Application.CQRS.Role.Commands.AddRole;

namespace TK_Project.Application.Validators.UserValidators
{
    public class AddRoleCommandRequestValidator : AbstractValidator<AddRoleCommandRequest>
    {
        public AddRoleCommandRequestValidator()
        {
            RuleFor(X => X.Name).NotEmpty().WithMessage("Ad boş bırakılamaz");
        }
    }
}
