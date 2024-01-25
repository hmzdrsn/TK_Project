using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TK_Project.Application.CQRS.Role.Commands.AddRole;
using TK_Project.Application.CQRS.Role.Commands.AssignRole;
using TK_Project.Application.CQRS.Role.Commands.RemoveRole;
using TK_Project.Application.CQRS.Role.Commands.UpdateRole;
using TK_Project.Application.CQRS.Role.Queries.GetAllRole;

namespace TK_Project.Role.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IMediator _mediator;
        private IValidator<AddRoleCommandRequest> _roleValidator;
        public RoleController(IMediator mediator, IValidator<AddRoleCommandRequest> roleValidator)
        {
            _mediator = mediator;
            _roleValidator = roleValidator;
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task <IActionResult> GetAll()
        {
            GetAllRoleQueryRequest request = new GetAllRoleQueryRequest();
            GetAllRoleQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddRole")]
        public async Task <IActionResult> AddRole(AddRoleCommandRequest request)
        {
            var result = await _roleValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                AddRoleCommandResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            return BadRequest(result.Errors);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateRole")]
        public async Task <IActionResult> UpdateRole(UpdateRoleCommandRequest request)
        {
            UpdateRoleCommandResponse response =  await _mediator.Send(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            RemoveRoleCommandRequest request = new RemoveRoleCommandRequest() { RoleID =id };
            RemoveRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("AssignRole")]
        public async Task<IActionResult> AssignRole(AssignRoleCommandRequest request)
        {
            AssignRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}