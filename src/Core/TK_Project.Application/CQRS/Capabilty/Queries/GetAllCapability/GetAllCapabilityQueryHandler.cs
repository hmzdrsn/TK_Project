using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Capability;

namespace TK_Project.Application.CQRS.Capabilty.Queries.GetAllCapability
{
    public class GetAllCapabilityQueryHandler : IRequestHandler<GetAllCapabilityQueryRequest, GetAllCapabilityQueryResponse>
    {
        readonly ICapabilityReadRepository _read;

        public GetAllCapabilityQueryHandler(ICapabilityReadRepository read)
        {
            _read = read;
        }

        public async Task<GetAllCapabilityQueryResponse> Handle(GetAllCapabilityQueryRequest request, CancellationToken cancellationToken)
        {
            var data =  await _read.GetAllAsync();

            var result = data.Select(x => new
            {
                CapabiltyID = x.Id, CapabiltyName = x.Name
            });

            return new GetAllCapabilityQueryResponse()
            {
                CapabiltyList = result
            };
        }
    }
}
