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
    public class RoleWriteRepository : WriteRepository<Domain.Entities.Role>, IRoleWriteRepository
    {
        readonly ApplicationDbContext _context;
        public RoleWriteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.User> AssignRole(int customerID, List<int> roleIDList)
        {
            List<Domain.Entities.Role> roleList = new List<Domain.Entities.Role>();
            foreach (var item in roleIDList)
            {
                var role = await _context.Roles.Where(x => x.Id == item).FirstOrDefaultAsync();
                roleList.Add(role);
            }
            var customerData = await _context.Users.Include(x => x.Roles).Where(y => y.Id == customerID).FirstOrDefaultAsync();

            customerData.Roles = roleList;

            _context.Set<Domain.Entities.User>().Update(customerData);
            _context.SaveChangesAsync();

            return customerData;
        }
    }
}
