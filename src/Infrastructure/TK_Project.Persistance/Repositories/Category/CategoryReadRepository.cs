using TK_Project.Application.Interfaces.Repositories.Category;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Category
{
    public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
