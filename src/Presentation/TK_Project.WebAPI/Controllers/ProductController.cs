using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.CQRS.Product.Commands.AddProduct;
using TK_Project.Application.CQRS.Product.Commands.RemoveProduct;
using TK_Project.Application.CQRS.Product.Commands.UpdateProduct;
using TK_Project.Application.CQRS.Product.Queries.GetAllProduct;
using TK_Project.Application.CQRS.Product.Queries.GetByIDProduct;
using TK_Project.Application.CQRS.Product.Queries.GetProductsByCategory;
using TK_Project.Domain.Entities;
using TK_Project.Persistance.Context;

namespace TK_Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;
        readonly ApplicationDbContext _context;
        public ProductController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GetAllProductQueryRequest request = new();
            GetAllProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetByIDProductQueryRequest request = new GetByIDProductQueryRequest() { ProductID = id };
            GetByIDProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("GetProductsByCategory")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            GetProductsByCategoryQueryRequest request = new GetProductsByCategoryQueryRequest() { CategoryId = id };
            GetProductsByCategoryQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductCommandRequest request)
        {
            AddProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(RemoveProductCommandRequest request)
        {
            RemoveProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
