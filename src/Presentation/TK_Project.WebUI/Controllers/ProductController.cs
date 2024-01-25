using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Domain.Entities;
using TK_Project.WebUI.Extensions;

namespace TK_Project.WebUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        readonly IProductReadRepository _read;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IValidator<Product> _validator;
        public ProductController(IProductReadRepository read, IProductWriteRepository productWriteRepository, IValidator<Product> validator)
        {
            _read = read;
            _productWriteRepository = productWriteRepository;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var data = await _read.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _validator.ValidateAsync(product);

            if (result.IsValid)
            {
                await _productWriteRepository.AddAsync(product);
                return RedirectToAction("ProductList", "Product");
            }
            
            result.AddToModelState(this.ModelState);
            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var data = await _read.GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Domain.Entities.Product product)
        {
            await _productWriteRepository.UpdateAsync(product);
            return RedirectToAction("ProductList", "Product");
        }


        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productWriteRepository.DeleteByIDAsync(id);
            return RedirectToAction("ProductList", "Product");
        }

    }
}
