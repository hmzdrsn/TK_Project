using MediatR;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.CQRS.User.Commands.AddUser;
using TK_Project.Application.CQRS.User.Commands.RemoveUser;
using TK_Project.Application.CQRS.User.Commands.UpdateCustomer;
using TK_Project.Application.CQRS.User.Queries.GetAllCustomer;
using TK_Project.Application.CQRS.User.Queries.GetByID;

namespace TK_Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GetAllUserQueryRequest request = new GetAllUserQueryRequest();
            GetAllUserQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetByIDUserQueryRequest request = new GetByIDUserQueryRequest() { ProductID = id };
            GetByIDUserQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AddUserCommandRequest request)
        {
            AddUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            UpdateUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(RemoveUserCommandRequest request)
        {
            RemoveUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
