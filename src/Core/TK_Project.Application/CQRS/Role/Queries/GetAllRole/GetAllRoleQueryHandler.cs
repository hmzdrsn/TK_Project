using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Role;

namespace TK_Project.Application.CQRS.Role.Queries.GetAllRole
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, GetAllRoleQueryResponse>
    {
        readonly IRoleReadRepository _read;

        public GetAllRoleQueryHandler(IRoleReadRepository read)
        {
            _read = read;
        }

        public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var data =  await _read.GetAllAsync();

            var result = data.Select(x => new
            {
                RoleID = x.Id,
                RoleName =x.Name,
            });

            return new()
            {
                Roles = result
            };
        }
    }
}
