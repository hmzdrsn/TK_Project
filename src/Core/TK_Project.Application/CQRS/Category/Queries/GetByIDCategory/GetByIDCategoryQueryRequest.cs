using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Category.Queries.GetByIDCategory
{
    public class GetByIDCategoryQueryRequest : IRequest<GetByIDCategoryQueryResponse>
    {
        public int ID { get; set; }
    }
}
