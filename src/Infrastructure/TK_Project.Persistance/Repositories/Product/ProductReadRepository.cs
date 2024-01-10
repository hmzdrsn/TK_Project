using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<Domain.Entities.Product>, IProductReadRepository
    {
        readonly ApplicationDbContext _context;
        public ProductReadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<decimal>> GetProductPriceListByOrderIdList(List<int> intList)
        {
            List<decimal> dbList=new();

            foreach (var item in intList)
            {
                var data =await _context.Set<Domain.Entities.Product>().Where(x => x.Id == item).Select(y => y.Price ?? 0).FirstOrDefaultAsync();
                dbList.Add(data);
            }

            return dbList;

        }

        public async Task<List<Domain.Entities.Product>> GetProductsByCategory(int id)
        {
            var data = await _context.Products.Include(x=>x.Category).Where(y=>y.Category.Id==id).ToListAsync();
            return data;
        }

        public async Task<List<Domain.Entities.Product>> GetProductsOfOrder(List<int> intList)
        {
            List<Domain.Entities.Product> dbList = new();

            foreach (var item in intList)
            {
                var data = await _context.Set<Domain.Entities.Product>().Where(x => x.Id == item).FirstOrDefaultAsync();
                dbList.Add(data);
            }

            return dbList;
        }

        public async Task<List<Domain.Entities.Product>> GetProductWithCategoryandOrder()
        {
            var data =await _context.Products.Include(x => x.Category).Include(y => y.Orders).ToListAsync();
            return data;
        }

        public async Task<List<Domain.Entities.Product>> GetProductWithCategoryandOrderByID(int id)
        {
            var data = await _context.Products.Where(x=>x.Id==id).Include(x => x.Category).Include(y => y.Orders).ToListAsync();
            return data;
        }
    }
}
