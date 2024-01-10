using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Role;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Role
{
    public class RoleReadRepository : ReadRepository<Domain.Entities.Role>, IRoleReadRepository
    {
        readonly ApplicationDbContext _context;
        public RoleReadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Role>> GetRolesByID(List<int> roleIDs)
        {
            List<Domain.Entities.Role> roleList = new List<Domain.Entities.Role>();

            foreach (int item in roleIDs)
            {
                var data = await _context.Set<Domain.Entities.Role>().Where(x => x.Id == item).FirstOrDefaultAsync();
                roleList.Add(data);
            }

            return roleList;
        }

        public async Task<Domain.Entities.User> GetUserRoles(int id)
        {
            var data = await _context.Users.Include(x => x.Roles).Where(x => x.Id == id).FirstOrDefaultAsync();
            //var data2 = await _context.Users.Where(u=>u.Id==id).Include(x=>x.Roles.Select(y=>y.Id)).FirstAsync();
            //var data =await _context.Users.Include(x => x.Roles).Select(x => x.Roles).ToListAsync();
            //List<int> userRoles = new List<int>();
            //foreach (var role in data)
            //{

            //    //userRoles.Add(role.Select(x => x.Id).First());
            //}

            return data;
        }
    }
}
