using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Role.Commands.AddRole
{
    public class AddRoleCommandRequest :IRequest<AddRoleCommandResponse>
    {
        public string Name { get; set; }
    }
}
