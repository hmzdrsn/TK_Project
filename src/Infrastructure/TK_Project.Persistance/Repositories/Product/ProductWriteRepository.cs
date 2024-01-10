using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
