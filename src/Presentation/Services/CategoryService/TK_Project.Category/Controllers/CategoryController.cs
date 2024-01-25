using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.CQRS.Category.Commands.AddCategory;
using TK_Project.Application.CQRS.Category.Commands.RemoveCategory;
using TK_Project.Application.CQRS.Category.Commands.UpdateCategory;
using TK_Project.Application.CQRS.Category.Queries.GetAllCategory;
using TK_Project.Application.CQRS.Category.Queries.GetByIDCategory;

namespace TK_Project.Category.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IValidator<AddCategoryCommandRequest> _categoryValidator;
        IMediator _mediator;
        private ILogger<CategoryController> _logger;
        public CategoryController(IMediator mediator, IValidator<AddCategoryCommandRequest> categoryValidator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _categoryValidator = categoryValidator;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetAll Category");
            GetAllCategoryQueryRequest request = new GetAllCategoryQueryRequest();
            var values = await _mediator.Send(request);
            return Ok(values);
        }
        [Authorize(Roles = "Admin,Member")]
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetByIDCategoryQueryRequest request = new GetByIDCategoryQueryRequest() { ID= id};
            GetByIDCategoryQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryCommandRequest request)
        {
            var result = await _categoryValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                AddCategoryCommandResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            return BadRequest(result.Errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(RemoveCategoryCommandRequest request)
        {
            RemoveCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
