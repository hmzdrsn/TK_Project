using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.Interfaces.Repositories.Order;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.CQRS.Order.Queries.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        readonly IOrderReadRepository _read;

        public GetAllOrderQueryHandler(IOrderReadRepository read)
        {
            _read = read;

        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _read.GetOrderWithProductandUser();

            var orderModel = data.Select(x => new
            {
                OrderID = x.Id,
                CustomerID = x.User.Id,
                ProductList = x.Products.Select(x => x.Id).ToList(),
                Amount = x.Amount ?? 0,
                Payment_Status = x.Payment_Status ?? "yok",
                Order_Date = x.Date,
            }).ToList();

            return new()
            {
                orderList = orderModel,
            };
        }
    }
}
