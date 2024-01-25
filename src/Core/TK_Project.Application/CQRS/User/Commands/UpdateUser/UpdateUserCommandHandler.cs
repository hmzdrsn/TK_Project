using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;

namespace TK_Project.Application.CQRS.User.Commands.UpdateCustomer
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        readonly IUserWriteRepository _write;
        readonly IUserReadRepository _read;

        public UpdateUserCommandHandler(IUserWriteRepository write, IUserReadRepository read)
        {
            _write = write;
            _read = read;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _read.GetByIdAsync(request.UserID);
            
            if (product == null)
            {
                return new()
                {
                    Message = "No Data"
                };
            }
            else
            {
                product.Username = request.Username;
                product.Password = request.Password;
                product.First_Name = request.First_Name;
                product.Last_Name = request.Last_Name;
                product.Address = request.Address;
                product.Mail = request.Mail;
                product.Phone_Number = request.Phone_Number;

                await _write.UpdateAsync(product);
                return new()
                {
                    Message = "User Updated"
                };
            }
            
        }
    }
}
