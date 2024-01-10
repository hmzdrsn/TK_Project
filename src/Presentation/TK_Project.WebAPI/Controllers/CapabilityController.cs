using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.CQRS.Capabilty.Commands.AddCapability;
using TK_Project.Application.CQRS.Capabilty.Commands.RemoveCapability;
using TK_Project.Application.CQRS.Capabilty.Commands.UpdateCapability;
using TK_Project.Application.CQRS.Capabilty.Queries.GetAllCapability;

namespace TK_Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapabilityController : ControllerBase
    {
        IMediator _mediator;

        public CapabilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCapability()
        {
            GetAllCapabilityQueryRequest request = new GetAllCapabilityQueryRequest();
            GetAllCapabilityQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("AddCapability")]
        public async Task<IActionResult> AddCapability(AddCapabilityCommandRequest request)
        {
            AddCapabilityCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("UpdateCapability")]
        public async Task<IActionResult> UpdateCapability(UpdateCapabilityCommandRequest request)
        {
            UpdateCapabilityCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("DeleteCapability")]
        public async Task<IActionResult> DeleteCapability(int id)
        {
            RemoveCapabilityCommandRequest request = new RemoveCapabilityCommandRequest() { CapabiltyID = id };
            RemoveCapabilityCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
