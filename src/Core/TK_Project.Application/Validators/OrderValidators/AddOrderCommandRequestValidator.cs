using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.CQRS.Order.Commands.AddOrder;

namespace TK_Project.Application.Validators.OrderValidators
{
    public class AddOrderCommandRequestValidator : AbstractValidator<AddOrderCommandRequest>
    {
        //public string? Payment_Status { get; set; }
        //public DateTime? Date { get; set; }
        //public int UserID { get; set; }

        //public List<int> ListProductID { get; set; }
        public AddOrderCommandRequestValidator()
        {
            RuleFor(x => x.Payment_Status).NotEmpty().WithMessage("Ödeme Durumu boş bırakılamaz.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih boş bırakılamaz.");
            RuleFor(x => x.UserID).NotEmpty().WithMessage("Kullanıcı ID boş bırakılamaz.");

        }
    }
}
