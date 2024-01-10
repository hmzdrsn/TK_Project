using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Role;

namespace TK_Project.Application.CQRS.Role.Commands.AddRole
{
    public class RemoveRoleCommandHandler : IRequestHandler<AddRoleCommandRequest, AddRoleCommandResponse>
    {
        readonly IRoleWriteRepository _write;

        public RemoveRoleCommandHandler(IRoleWriteRepository write)
        {
            _write = write;
        }

        public async Task<AddRoleCommandResponse> Handle(AddRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.AddAsync(new Domain.Entities.Role()
            {
                Name = request.Name
            });
            return new AddRoleCommandResponse() { Message="Rol Başarıyla Eklendi"};
        }
    }
}
