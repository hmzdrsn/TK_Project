using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Role;

namespace TK_Project.Application.CQRS.Role.Commands.RemoveRole
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommandRequest, RemoveRoleCommandResponse>
    {
        readonly IRoleWriteRepository _write;

        public RemoveRoleCommandHandler(IRoleWriteRepository write)
        {
            _write = write;
        }

        public async Task<RemoveRoleCommandResponse> Handle(RemoveRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.DeleteByIDAsync(request.RoleID);
            
            return new RemoveRoleCommandResponse() { Message="Rol Başarıyla Silindi"};
        }
    }
}
