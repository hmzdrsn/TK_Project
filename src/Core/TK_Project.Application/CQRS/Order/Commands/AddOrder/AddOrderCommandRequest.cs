using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Order.Commands.AddOrder
{
    public class AddOrderCommandRequest : IRequest<AddOrderCommandResponse>
    {

        public string? Payment_Status { get; set; }
        public DateTime? Date { get; set; }
        public int UserID { get; set; }

        public List<int> ListProductID { get; set; }
    }
}
