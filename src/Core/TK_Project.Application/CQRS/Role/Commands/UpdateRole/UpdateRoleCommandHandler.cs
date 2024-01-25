using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Role;

namespace TK_Project.Application.CQRS.Role.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        readonly IRoleWriteRepository _write;
        readonly IRoleReadRepository _read;

        public UpdateRoleCommandHandler(IRoleWriteRepository write, IRoleReadRepository read)
        {
            _write = write;
            _read = read;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _read.GetByIdAsync(request.RoleID);
            if(role == null)
            {
                return new UpdateRoleCommandResponse()
                {
                    Message = "No Data"
                };
            }
            else
            {
                role.Name = request.RoleName;
                await _write.UpdateAsync(role);
                return new UpdateRoleCommandResponse()
                {
                    Message = "Role Updated"
                };
            }
            
            
        }
    }
}
