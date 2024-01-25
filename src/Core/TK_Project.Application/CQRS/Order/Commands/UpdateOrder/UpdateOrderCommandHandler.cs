using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.Interfaces.Repositories.Order;

namespace TK_Project.Application.CQRS.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        readonly IOrderWriteRepository _write;
        readonly IOrderReadRepository _read;
        public UpdateOrderCommandHandler(IOrderWriteRepository write, IOrderReadRepository read)
        {
            _write = write;
            _read = read;
        }

        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _read.GetByIdAsync(request.OrderID);
            if(order == null)
            {
                return new UpdateOrderCommandResponse()
                {
                    Message = "No Data"
                };
            }
            else
            {
                order.Date = request.Date;
                order.Payment_Status = request.Payment_Status;
                await _write.UpdateAsync(order);
                return new UpdateOrderCommandResponse()
                {
                    Message = "Order Updated"
                };
            }
            
            
        }
    }
}
