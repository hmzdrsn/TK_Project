using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Capability;

namespace TK_Project.Application.CQRS.Capabilty.Commands.UpdateCapability
{
    public class UpdateCapabilityCommandHandler : IRequestHandler<UpdateCapabilityCommandRequest, UpdateCapabilityCommandResponse>
    {
        readonly ICapabilityWriteRepository _write;

        public UpdateCapabilityCommandHandler(ICapabilityWriteRepository write)
        {
            _write = write;
        }

        public async Task<UpdateCapabilityCommandResponse> Handle(UpdateCapabilityCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.UpdateAsync(new Domain.Entities.Capability()
            {
                Id=  request.CapabiltyID,
                Name = request.Name
            });

            return new UpdateCapabilityCommandResponse()
            {
                Message = "Yetkinlik Güncellendi"
            };
        }
    }
}
