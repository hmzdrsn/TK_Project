using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Product.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryRequest : IRequest<GetProductsByCategoryQueryResponse>
    {
        public int CategoryId { get; set; }
    }
}
