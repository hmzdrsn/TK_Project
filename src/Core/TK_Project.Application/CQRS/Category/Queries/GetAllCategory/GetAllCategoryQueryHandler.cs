using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Category;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.CQRS.Category.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _categoryReadRepository.GetAllAsync();

            var categoryListModel = data.Select(x => new
            {
                x.Id,
                x.Name
            });

            return new GetAllCategoryQueryResponse() { CategoryList = categoryListModel };
        }
    }
}
