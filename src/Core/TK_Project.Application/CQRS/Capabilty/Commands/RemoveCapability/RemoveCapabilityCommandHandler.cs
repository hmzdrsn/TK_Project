using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Capability;

namespace TK_Project.Application.CQRS.Capabilty.Commands.RemoveCapability
{
    public class RemoveCapabilityCommandHandler : IRequestHandler<RemoveCapabilityCommandRequest, RemoveCapabilityCommandResponse>
    {
        readonly ICapabilityWriteRepository _write;

        public RemoveCapabilityCommandHandler(ICapabilityWriteRepository write)
        {
            _write = write;
        }

        public async Task<RemoveCapabilityCommandResponse> Handle(RemoveCapabilityCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.DeleteByIDAsync(request.CapabiltyID);
            return new()
            {
                Message = $"{request.CapabiltyID} Id'li Yetkinlik Silindi"
            };
        }
    }
}
