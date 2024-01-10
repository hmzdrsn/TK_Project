using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Order;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.CQRS.Product.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _read;

        public GetAllProductQueryHandler(IProductReadRepository read)
        {
            _read = read;

        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _read.GetProductWithCategoryandOrder();

            var products = data.Select(x => new
            {
                ID = x.Id,
                x.Name,
                x.Description,
                x.Price,
                x.Stock,
                CategoryName = x.Category.Name,
                Orders = x.Orders.Select(y => y.Id)
            }).ToList();

            return new()
            {
                Products = products
            };
        }
    }
}
