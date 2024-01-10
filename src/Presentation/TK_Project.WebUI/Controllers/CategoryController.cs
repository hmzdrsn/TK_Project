using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Repositories.Category;

namespace TK_Project.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;
        public CategoryController(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _categoryReadRepository.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Domain.Entities.Category category)
        {
            await _categoryWriteRepository.AddAsync(category);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var data = await _categoryReadRepository.GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Domain.Entities.Category category)
        {
            await _categoryWriteRepository.UpdateAsync(category);
            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryWriteRepository.DeleteByIDAsync(id);
            return RedirectToAction("Index", "Category");
        }
    }
}
