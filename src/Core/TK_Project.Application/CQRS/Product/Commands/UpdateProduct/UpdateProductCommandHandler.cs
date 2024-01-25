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
        readonly IProductReadRepository _productRead;
        readonly ICategoryReadRepository _readCategory;
        public UpdateProductCommandHandler(IProductWriteRepository write, ICategoryReadRepository read, IProductReadRepository productRead)
        {
            _write = write;
            _readCategory = read;
            _productRead = productRead;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _readCategory.GetByIdAsync(request.CategoryID);
            var product = await _productRead.GetByIdAsync(request.ProductID);

            if (product == null)
            {
                return new UpdateProductCommandResponse()
                {
                    Message = "No Data"
                };
            }
            else
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.Status = request.Status;
                product.Category = data;
                await _write.UpdateAsync(product);
                return new UpdateProductCommandResponse()
                {
                    Message = "Product Updated"
                };
            }
            
            
        }
    }
}
