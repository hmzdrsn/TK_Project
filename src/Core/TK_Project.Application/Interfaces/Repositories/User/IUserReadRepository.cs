using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.Interfaces.Repositories.User
{
    public interface IUserReadRepository : IReadRepository<Domain.Entities.User>
    {
        Task<List<Domain.Entities.User>> GetUserWithOrderIds();
        Task<List<Domain.Entities.User>> GetUserWithOrderById(int id);
        Task<Domain.Entities.User> GetUserByUsername(string name);
    }
}
