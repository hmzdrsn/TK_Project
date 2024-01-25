using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Order;
using TK_Project.Domain.Entities;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
    {
        readonly ApplicationDbContext _context;
        public OrderWriteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
