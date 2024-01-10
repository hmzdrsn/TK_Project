using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.User.Queries.GetAllCustomer
{
    public class GetAllUserQueryRequest : IRequest<GetAllUserQueryResponse>
    {
    }
}
