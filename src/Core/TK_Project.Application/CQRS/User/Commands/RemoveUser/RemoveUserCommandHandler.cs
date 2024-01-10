using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;
    
namespace TK_Project.Application.CQRS.User.Commands.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, RemoveUserCommandResponse>
    {
        readonly IUserWriteRepository _write;

        public RemoveUserCommandHandler(IUserWriteRepository write)
        {
            _write = write;
        }

        public async Task<RemoveUserCommandResponse> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.DeleteByIDAsync(request.UserID);
            return new()
            {
                Message = "Müşteri Başarıyla Silindi"
            };
        }
    }
}
