using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Capabilty.Queries.GetAllCapability
{
    public class GetAllCapabilityQueryRequest : IRequest<GetAllCapabilityQueryResponse>
    {
    }
}
