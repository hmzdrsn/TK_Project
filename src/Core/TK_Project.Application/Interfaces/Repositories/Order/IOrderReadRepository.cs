using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.Interfaces.Repositories.Order
{
    public interface IOrderReadRepository : IReadRepository<Domain.Entities.Order>
    {
        Task<List<Domain.Entities.Order>> GetOrderWithProduct();

        Task<List<Domain.Entities.Order>> GetOrderWithProductandUser();
        Task<List<Domain.Entities.Order>> GetOrderWithProductandUserByID(int id);
    }  
}
