using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Role.Commands.AssignRole
{
    public class AssignRoleCommandRequest : IRequest<AssignRoleCommandResponse>
    {
        public int userID { get; set; }
        public List<int> roleIdList { get; set; }
    }
}
