using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Repositories.Category;

namespace TK_Project.WebUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;
        public CategoryController(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<IActionResult> CategoryList()
        {
            var data = await _categoryReadRepository.GetAllAsync();
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(Domain.Entities.Category category)
        {
            await _categoryWriteRepository.AddAsync(category);
            return RedirectToAction("CategoryList", "Category");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var data = await _categoryReadRepository.GetByIdAsync(id);
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Domain.Entities.Category category)
        {
            await _categoryWriteRepository.UpdateAsync(category);
            return RedirectToAction("CategoryList", "Category");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryWriteRepository.DeleteByIDAsync(id);
            return RedirectToAction("CategoryList", "Category");
        }
    }
}
