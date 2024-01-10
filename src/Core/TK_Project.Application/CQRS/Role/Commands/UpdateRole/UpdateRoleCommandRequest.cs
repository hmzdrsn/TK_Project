using MediatR;

namespace TK_Project.Application.CQRS.Role.Commands.UpdateRole
{
    public class UpdateRoleCommandRequest :IRequest<UpdateRoleCommandResponse>
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
