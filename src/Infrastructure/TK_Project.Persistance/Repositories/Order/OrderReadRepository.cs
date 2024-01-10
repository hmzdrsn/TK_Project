using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Order;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
    {
        readonly ApplicationDbContext _context;
        public OrderReadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Order>> GetOrderWithProduct()
        {
            var data =await _context.Orders.Include(x => x.Products).ToListAsync();
            return data;
        }

        public async Task<List<Domain.Entities.Order>> GetOrderWithProductandUser()
        {
            var data = await _context.Orders.Include(x => x.Products).Include(y => y.User).ToListAsync();
            return data;
        }

        public async Task<List<Domain.Entities.Order>> GetOrderWithProductandUserByID(int id)
        {
            var data = await _context.Orders.Where(x => x.Id == id).Include(x => x.Products).Include(y => y.User).ToListAsync();
            return data;
        }

    }
}
