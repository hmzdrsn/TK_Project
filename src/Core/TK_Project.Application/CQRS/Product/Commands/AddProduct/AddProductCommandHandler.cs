using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Category;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.CQRS.Product.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        readonly IProductWriteRepository _write;
        readonly ICategoryReadRepository _readCategory;
        public AddProductCommandHandler(IProductWriteRepository write, ICategoryReadRepository read)
        {
            _write = write;
            _readCategory = read;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _readCategory.GetByIdAsync(request.CategoryID);


            await _write.AddAsync(new Domain.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Category = category,
                Status = request.Status,
            });

            return new AddProductCommandResponse() { Message = "Product Created" };
        }
    }
}
