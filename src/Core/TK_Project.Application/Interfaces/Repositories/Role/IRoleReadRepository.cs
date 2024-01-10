using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.Interfaces.Repositories.Role
{
    public interface IRoleReadRepository : IReadRepository<Domain.Entities.Role>
    {
        Task<List<Domain.Entities.Role>> GetRolesByID(List<int> roleIDs);
        Task<Domain.Entities.User> GetUserRoles(int id);
    }
}
