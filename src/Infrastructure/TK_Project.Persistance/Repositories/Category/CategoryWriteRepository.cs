using TK_Project.Application.Interfaces.Repositories.Category;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>,ICategoryWriteRepository
    {
        public CategoryWriteRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
