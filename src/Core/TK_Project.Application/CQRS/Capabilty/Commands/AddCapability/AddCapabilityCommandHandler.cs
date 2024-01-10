using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Capability;

namespace TK_Project.Application.CQRS.Capabilty.Commands.AddCapability
{
    public class AddCapabilityCommandHandler : IRequestHandler<AddCapabilityCommandRequest, AddCapabilityCommandResponse>
    {
        readonly ICapabilityWriteRepository _write;
        public AddCapabilityCommandHandler(ICapabilityWriteRepository write)
        {
            _write = write;
        }

        public async Task<AddCapabilityCommandResponse> Handle(AddCapabilityCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.AddAsync(new Domain.Entities.Capability
            {
                Name = request.Name
            });
            
            return new AddCapabilityCommandResponse() { Message ="Eklendi"};
        }
    }

    
}
