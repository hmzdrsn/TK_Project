using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.CQRS.Order.Commands.AddOrder;
using TK_Project.Application.CQRS.Order.Commands.RemoveOrder;
using TK_Project.Application.CQRS.Order.Commands.UpdateOrder;
using TK_Project.Application.CQRS.Order.Queries.GetAllOrder;
using TK_Project.Application.CQRS.Order.Queries.GetByIDOrder;

namespace TK_Project.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMediator _mediator;
        private IValidator<AddOrderCommandRequest> _orderValidator;

        public OrderController(IMediator mediator, IValidator<AddOrderCommandRequest> orderValidator)
        {
            _mediator = mediator;
            _orderValidator = orderValidator;
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GetAllOrderQueryRequest request = new GetAllOrderQueryRequest();
            var values = await _mediator.Send(request);
            return Ok(values);
        }
        [Authorize(Roles = "Admin,Member")]
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetByIDOrderQueryRequest request = new GetByIDOrderQueryRequest() { OrderID = id };
            GetByIDOrderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(AddOrderCommandRequest request)
        {
            var result = await _orderValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                AddOrderCommandResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            return BadRequest(result.Errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommandRequest request)
        {
            UpdateOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(RemoveOrderCommandRequest request)
        {
            RemoveOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
