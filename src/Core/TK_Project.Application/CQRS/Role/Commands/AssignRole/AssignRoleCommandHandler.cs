using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.Interfaces.Repositories.Role;

namespace TK_Project.Application.CQRS.Role.Commands.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommandRequest, AssignRoleCommandResponse>
    {
        readonly IRoleWriteRepository _write;
        public AssignRoleCommandHandler(IRoleWriteRepository write)
        {
            _write = write;
        }

        public async Task<AssignRoleCommandResponse> Handle(AssignRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.AssignRole(request.userID,request.roleIdList);
            return new AssignRoleCommandResponse()
            {
                Message= "Rol Atandı"
            };
        }
    }
}
