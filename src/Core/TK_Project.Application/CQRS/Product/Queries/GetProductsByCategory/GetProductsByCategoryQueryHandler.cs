using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Product;

namespace TK_Project.Application.CQRS.Product.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQueryRequest, GetProductsByCategoryQueryResponse>
    {
        readonly IProductReadRepository _read;

        public GetProductsByCategoryQueryHandler(IProductReadRepository read)
        {
            _read = read;
        }

        public async Task<GetProductsByCategoryQueryResponse> Handle(GetProductsByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _read.GetProductsByCategory(request.CategoryId);
            var model = data.Select(x => new
            {
                KategoriAdi = x.Category.Name,
                UrunAdi = x.Name,
                Fiyat= x.Price,
                StokMiktari = x.Stock
            }).ToList();
            
            return new()
            {
                ProductList = model
            };
        }
    }
}
