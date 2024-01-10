using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Capabilty.Commands.UpdateCapability
{
    public class UpdateCapabilityCommandRequest : IRequest<UpdateCapabilityCommandResponse>
    {
        public int CapabiltyID { get; set; }
        public string Name { get; set; }
    }
}
