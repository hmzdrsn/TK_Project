using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TK_Project.Application.Interfaces.Repositories.Product;

namespace TK_Project.WebUI.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductReadRepository _read;
        readonly IProductWriteRepository _productWriteRepository;
        public ProductController(IProductReadRepository read, IProductWriteRepository productWriteRepository)
        {
            _read = read;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var data = await _read.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails()
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
        public async Task<IActionResult> AddProduct(Domain.Entities.Product product)
        {
            await _productWriteRepository.AddAsync(product);
            return RedirectToAction("ProductDetails","Product");
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
            return RedirectToAction("ProductDetails", "Product");
        }


        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productWriteRepository.DeleteByIDAsync(id);
            return RedirectToAction("ProductDetails", "Product");
        }

    }
}
