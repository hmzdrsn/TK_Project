using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Order;

namespace TK_Project.Application.CQRS.Order.Queries.GetByIDOrder
{
    public class GetByIDOrderQueryHandler : IRequestHandler<GetByIDOrderQueryRequest, GetByIDOrderQueryResponse>
    {
        readonly IOrderReadRepository _read;

        public GetByIDOrderQueryHandler(IOrderReadRepository read)
        {
            _read = read;
        }

        public async Task<GetByIDOrderQueryResponse> Handle(GetByIDOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _read.GetOrderWithProductandUserByID(request.OrderID);

            var orderListModel = data.Select(x => new
            {
                UserID = x.User.Id,
                ProductList = x.Products.Select(x => x.Id),
                x.Amount,
                x.Payment_Status,
                Order_Date = x.Date,
            });

            return new()
            {
                Order = orderListModel,
            };
        }
    }
}
