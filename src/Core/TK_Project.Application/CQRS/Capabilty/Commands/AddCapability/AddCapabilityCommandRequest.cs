using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.CQRS.Capabilty.Commands.AddCapability
{
    public class AddCapabilityCommandRequest: IRequest<AddCapabilityCommandResponse>
    {
        public string Name { get; set; }
    }
}
