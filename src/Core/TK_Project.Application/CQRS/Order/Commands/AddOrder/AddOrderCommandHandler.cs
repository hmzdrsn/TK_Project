using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.Interfaces.Repositories.Order;
using TK_Project.Application.Interfaces.Repositories.Product;

namespace TK_Project.Application.CQRS.Order.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        readonly IOrderWriteRepository _write;
        readonly IUserReadRepository _readUser;
        readonly IProductReadRepository _readProduct;
        public AddOrderCommandHandler(IOrderWriteRepository write, IUserReadRepository userRead, IProductReadRepository readProduct)
        {
            _write = write;
            _readUser = userRead;
            _readProduct = readProduct;
        }

        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
            decimal total = 0;
            //var listPrice = await _readProduct.GetProductPriceListByOrderIdList(request.ListProductID);
            var productList = await _readProduct.GetProductsOfOrder(request.ListProductID);
            if(productList != null)
            {
                foreach (var item in productList)
                {
                    total += (decimal)item.Price;
                }
            }
            else
            {
                return new AddOrderCommandResponse() { Message = "empty basket" };
            }
            
            var user = await _readUser.GetByIdAsync(request.UserID);
            if(user == null)
            {
                return new()
                {
                    Message = "no user"
                };
            }
            else
            {
                await _write.AddAsync(new Domain.Entities.Order()
                {
                    Date = request.Date,
                    Payment_Status = request.Payment_Status,
                    User = user,
                    Amount = total,
                    Products = productList,
                });
                return new AddOrderCommandResponse() { Message = "Order Created" };
            }
        }
    }
}
