using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Order.Queries.GetByIDOrder
{
    public class GetByIDOrderQueryRequest : IRequest<GetByIDOrderQueryResponse>
    {
        public int OrderID { get; set; }
    }
}
