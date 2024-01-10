using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.User.Queries.GetByID
{
    public class GetByIDUserQueryRequest : IRequest<GetByIDUserQueryResponse>
    {
        public int ProductID { get; set; }
    }
}
