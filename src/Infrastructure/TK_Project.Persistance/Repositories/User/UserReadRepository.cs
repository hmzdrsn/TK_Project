using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Customer
{
    public class UserReadRepository : ReadRepository<Domain.Entities.User>, IUserReadRepository
    {
        readonly ApplicationDbContext _context;
        public UserReadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Domain.Entities.User>> GetUserWithOrderIds()
        {
            var data = await _context.Users.Include(x => x.Orders).ToListAsync();

            return data;
        }

         public async Task<List<Domain.Entities.User>> GetUserWithOrderById(int id)
        {
            var data = await _context.Users.Where(x => x.Id == id).Include(x => x.Orders).ToListAsync();
            return data;
        }

        public async Task<Domain.Entities.User> GetUserByUsername(string name)
        {
            var data = await _context.Users.Include(r=>r.Roles).Where(x => x.Username == name).FirstOrDefaultAsync();
            return data;
        }
    }
}
