using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandRequest : IRequest<UpdateOrderCommandResponse>
    {
        public int OrderID { get; set; }
        public string? Payment_Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
