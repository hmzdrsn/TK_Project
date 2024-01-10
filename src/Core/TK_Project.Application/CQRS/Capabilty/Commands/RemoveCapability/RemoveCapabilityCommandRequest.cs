using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Capabilty.Commands.RemoveCapability
{
    public class RemoveCapabilityCommandRequest : IRequest<RemoveCapabilityCommandResponse>
    {
        public int CapabiltyID { get; set; }
    }
}
