using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Order;

namespace TK_Project.Application.CQRS.Order.Commands.RemoveOrder
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommandRequest, RemoveOrderCommandResponse>
    {
        readonly IOrderWriteRepository _write;
        public RemoveOrderCommandHandler(IOrderWriteRepository write)
        {
            _write = write;
        }
        public async Task<RemoveOrderCommandResponse> Handle(RemoveOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.DeleteByIDAsync(request.OrderID);

            return new RemoveOrderCommandResponse() { Message = "Order Removed" };
        }

    }
}
