﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Role.Commands.RemoveRole
{
    public class RemoveRoleCommandRequest : IRequest<RemoveRoleCommandResponse>
    {
        public int RoleID { get; set; }
    }
}
