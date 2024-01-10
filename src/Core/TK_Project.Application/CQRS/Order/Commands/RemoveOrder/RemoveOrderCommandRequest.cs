using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Order.Commands.RemoveOrder
{
    public class RemoveOrderCommandRequest : IRequest<RemoveOrderCommandResponse>
    {
        public int OrderID { get; set; }
    }
}
