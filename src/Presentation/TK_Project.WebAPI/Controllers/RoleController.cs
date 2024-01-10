using MediatR;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.CQRS.Role.Commands.AddRole;
using TK_Project.Application.CQRS.Role.Commands.AssignRole;
using TK_Project.Application.CQRS.Role.Commands.RemoveRole;
using TK_Project.Application.CQRS.Role.Commands.UpdateRole;
using TK_Project.Application.CQRS.Role.Queries.GetAllRole;

namespace TK_Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        public async Task <IActionResult> GetAll()
        {
            GetAllRoleQueryRequest request = new GetAllRoleQueryRequest();
            GetAllRoleQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("AddRole")]
        public async Task <IActionResult> AddRole(AddRoleCommandRequest request)
        {
            AddRoleCommandResponse response =  await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("UpdateRole")]
        public async Task <IActionResult> UpdateRole(UpdateRoleCommandRequest request)
        {
            UpdateRoleCommandResponse response =  await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            RemoveRoleCommandRequest request = new RemoveRoleCommandRequest() { RoleID =id };
            RemoveRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("AssignRole")]
        public async Task<IActionResult> AssignRole(AssignRoleCommandRequest request)
        {
            AssignRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
