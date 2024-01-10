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
        public UpdateOrderCommandHandler(IOrderWriteRepository write)
        {
            _write = write;
        }

        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.UpdateAsync(new Domain.Entities.Order()
            {
                Id = request.OrderID,
                Date = request.Date,
                Payment_Status = request.Payment_Status,
            });
            return new UpdateOrderCommandResponse()
            {
                Message = "Sipariş Bilgileri Güncellendi"
            };
        }
    }
}
