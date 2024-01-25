using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.Validators.ProductValidators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Bu alan boş bırakılamaz");

        }
    }
}
