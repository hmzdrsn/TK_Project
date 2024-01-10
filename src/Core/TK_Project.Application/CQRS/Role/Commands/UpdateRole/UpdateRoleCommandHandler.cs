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

        public UpdateRoleCommandHandler(IRoleWriteRepository write)
        {
            _write = write;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.UpdateAsync(new Domain.Entities.Role()
            {
                Id = request.RoleID,
                Name = request.RoleName
            });
            return new UpdateRoleCommandResponse()
            {
                Message = "Rol Başarıyla Güncellendi"
            };
        }
    }
}
