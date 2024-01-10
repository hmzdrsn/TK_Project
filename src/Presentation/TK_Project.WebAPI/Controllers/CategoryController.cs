using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TK_Project.Application.CQRS.Category.Commands.AddCategory;
using TK_Project.Application.CQRS.Category.Commands.RemoveCategory;
using TK_Project.Application.CQRS.Category.Commands.UpdateCategory;
using TK_Project.Application.CQRS.Category.Queries.GetAllCategory;
using TK_Project.Application.CQRS.Category.Queries.GetByIDCategory;

namespace TK_Project.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoryController : ControllerBase
    {
        IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            GetAllCategoryQueryRequest request = new GetAllCategoryQueryRequest();
            var values = await _mediator.Send(request);
            return Ok(values);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetByIDCategoryQueryRequest request = new GetByIDCategoryQueryRequest() { ID= id};
            GetByIDCategoryQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryCommandRequest request)
        {
            AddCategoryCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(RemoveCategoryCommandRequest request)
        {
            RemoveCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
