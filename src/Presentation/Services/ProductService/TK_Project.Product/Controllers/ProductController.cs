using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.CQRS.Product.Commands.AddProduct;
using TK_Project.Application.CQRS.Product.Commands.RemoveProduct;
using TK_Project.Application.CQRS.Product.Commands.UpdateProduct;
using TK_Project.Application.CQRS.Product.Queries.GetAllProduct;
using TK_Project.Application.CQRS.Product.Queries.GetByIDProduct;
using TK_Project.Application.CQRS.Product.Queries.GetProductsByCategory;
using TK_Project.Persistance.Context;

namespace TK_Project.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IValidator<AddProductCommandRequest> _productValidator;
        IMediator _mediator;
        readonly ApplicationDbContext _context;
        public ProductController(IMediator mediator, ApplicationDbContext context, IValidator<AddProductCommandRequest> productValidator)
        {
            _mediator = mediator;
            _context = context;
            _productValidator = productValidator;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GetAllProductQueryRequest request = new();
            GetAllProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [Authorize(Roles ="Admin,Member")]
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetByIDProductQueryRequest request = new GetByIDProductQueryRequest() { ProductID = id };
            GetByIDProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [Authorize(Roles ="Admin,Member")]
        [HttpGet("GetProductsByCategory/{id}")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            GetProductsByCategoryQueryRequest request = new GetProductsByCategoryQueryRequest() { CategoryId = id };
            GetProductsByCategoryQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductCommandRequest request)
        {
            var result = await _productValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                AddProductCommandResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            return BadRequest(result.Errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(RemoveProductCommandRequest request)
        {
            RemoveProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
