using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Category;
using TK_Project.Application.Interfaces.Repositories.Product;

namespace TK_Project.Application.CQRS.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductWriteRepository _write;
        readonly ICategoryReadRepository _read;
        public UpdateProductCommandHandler(IProductWriteRepository write, ICategoryReadRepository read)
        {
            _write = write;
            _read = read;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _read.GetByIdAsync(request.CategoryID);

            await _write.UpdateAsync(new Domain.Entities.Product()
            {
                Id = request.ProductID,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Status = request.Status,
                Category = data,
            });
            return new UpdateProductCommandResponse()
            {
                Message = "Ürün Başarıyla Güncellendi"
            };
        }
    }
}
