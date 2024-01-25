using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.CQRS.Category.Commands.AddCategory;

namespace TK_Project.Application.Validators.CategoryValidators
{
    public class AddCategoryCommandRequestValidator : AbstractValidator<AddCategoryCommandRequest>
    {
        public AddCategoryCommandRequestValidator()
        {
            RuleFor(X => X.Name).NotEmpty().WithMessage("Ad boş bırakılamaz");
        }
    }
}
