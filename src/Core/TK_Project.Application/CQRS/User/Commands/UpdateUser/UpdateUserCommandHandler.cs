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

        public UpdateUserCommandHandler(IUserWriteRepository write)
        {
            _write = write;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.UpdateAsync(new()
            {
                Id = request.UserID,
                Username = request.Username,
                Password = request.Password,
                First_Name = request.First_Name,
                Last_Name = request.Last_Name,
                Address = request.Address,
                Mail = request.Mail,
                Phone_Number = request.Phone_Number
            });
            return new()
            {
                Message = "Müşteri Bilgileri Başarıyla Güncellendi"
            };
        }
    }
}
