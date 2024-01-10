using Microsoft.AspNetCore.Mvc;
using TK_Project.Application.Interfaces.Repositories.Order;
namespace TK_Project.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        public OrderController(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }
        public async Task <IActionResult> Index()
        {
            var data = await _orderReadRepository.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Domain.Entities.Order order)
        {
            await _orderWriteRepository.AddAsync(order);
            return RedirectToAction("Index", "Order");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var data = await _orderReadRepository.GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Domain.Entities.Order order)
        {
            await _orderWriteRepository.UpdateAsync(order);
            return RedirectToAction("Index", "Order");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderWriteRepository.DeleteByIDAsync(id);
            return RedirectToAction("Index", "Order");
        }
    }
}