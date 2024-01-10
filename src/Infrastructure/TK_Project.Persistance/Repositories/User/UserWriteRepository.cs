using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Customer
{
    public class UserWriteRepository : WriteRepository<Domain.Entities.User>, IUserWriteRepository
    {
        readonly ApplicationDbContext _context;
        public UserWriteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
