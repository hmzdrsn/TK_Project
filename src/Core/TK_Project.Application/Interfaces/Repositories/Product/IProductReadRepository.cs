using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.Interfaces.Repositories.Product
{
    public interface IProductReadRepository : IReadRepository<Domain.Entities.Product>
    {
        Task<List<Domain.Entities.Product>> GetProductsOfOrder(List<int> intList);
        Task<List<decimal>> GetProductPriceListByOrderIdList(List<int> intList);

        Task<List<Domain.Entities.Product>> GetProductWithCategoryandOrder();
        Task<List<Domain.Entities.Product>> GetProductWithCategoryandOrderByID(int id);

        Task<List<Domain.Entities.Product>> GetProductsByCategory(int id);
    }
}
