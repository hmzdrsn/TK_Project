using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Product.Queries.GetByIDProduct
{
    public class GetByIDProductQueryRequest : IRequest<GetByIDProductQueryResponse>
    {
        public int ProductID { get; set; }
    }
}
