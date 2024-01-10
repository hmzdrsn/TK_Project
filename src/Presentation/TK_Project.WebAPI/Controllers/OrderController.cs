using MediatR;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.CQRS.Order.Commands.AddOrder;
using TK_Project.Application.CQRS.Order.Commands.RemoveOrder;
using TK_Project.Application.CQRS.Order.Commands.UpdateOrder;
using TK_Project.Application.CQRS.Order.Queries.GetAllOrder;
using TK_Project.Application.CQRS.Order.Queries.GetByIDOrder;

namespace TK_Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            GetAllOrderQueryRequest request = new GetAllOrderQueryRequest();
            var values = await _mediator.Send(request);
            return Ok(values);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetByIDOrderQueryRequest request = new GetByIDOrderQueryRequest() { OrderID = id };
            GetByIDOrderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(AddOrderCommandRequest request)
        {
            AddOrderCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommandRequest request)
        {
            UpdateOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(RemoveOrderCommandRequest request)
        {
            RemoveOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
