using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Category;

namespace TK_Project.Application.CQRS.Category.Queries.GetByIDCategory
{
    public class GetByIDCategoryHandler : IRequestHandler<GetByIDCategoryQueryRequest, GetByIDCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _read;

        public GetByIDCategoryHandler(ICategoryReadRepository read)
        {
            _read = read;
        }

        public async Task<GetByIDCategoryQueryResponse> Handle(GetByIDCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _read.GetByIdAsync(request.ID);
            return new GetByIDCategoryQueryResponse()
            {
                Category = value
            };
        }
    }
}
