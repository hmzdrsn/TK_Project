using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories;
using TK_Project.Application.Interfaces.Repositories.Product;

namespace TK_Project.Application.CQRS.Product.Commands.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        readonly IProductWriteRepository _write;

        public RemoveProductCommandHandler(IProductWriteRepository write)
        {
            _write = write;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.DeleteByIDAsync(request.ProductID);
            return new RemoveProductCommandResponse()
            {
                Message = "Product Removed"
            };
        }
    }
}
