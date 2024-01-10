using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Product;

namespace TK_Project.Application.CQRS.Product.Queries.GetByIDProduct
{
    public class GetByIDProductQueryHandler : IRequestHandler<GetByIDProductQueryRequest, GetByIDProductQueryResponse>
    {
        readonly IProductReadRepository _read;

        public GetByIDProductQueryHandler(IProductReadRepository read)
        {
            _read = read;
        }

        public async Task<GetByIDProductQueryResponse> Handle(GetByIDProductQueryRequest request, CancellationToken cancellationToken)
        {
            //var model = await _read.GetByIdAsync(request.ProductID);
            //return new GetByIDProductQueryResponse()
            //{
            //    Product = model,
            //};
            var data = await _read.GetProductWithCategoryandOrderByID(request.ProductID);
            var productModel = data.Select(x => new
            {
                x.Name,
                x.Description,
                x.Price,
                x.Stock,
                CategoryName = x.Category.Name,
                Orders = x.Orders.Select(y => y.Id)
            }).FirstOrDefault();

            return new GetByIDProductQueryResponse()
            {
                Product = productModel
            };
        }
    }
}
