using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.CQRS.Product.Commands.AddProduct;

namespace TK_Project.Application.Validators.ProductValidators
{
    public class AddProductCommandRequestValidator :AbstractValidator<AddProductCommandRequest>
    {
        //public int CategoryID { get; set; }
        //public string? Name { get; set; }
        //public string? Description { get; set; }
        //public decimal? Price { get; set; }
        //public int? Stock { get; set; }
        public AddProductCommandRequestValidator()
        {
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori ID boş olamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat bilgisi boş olamaz");        
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok bilgisi boş olamaz");        
        }
    }
}
