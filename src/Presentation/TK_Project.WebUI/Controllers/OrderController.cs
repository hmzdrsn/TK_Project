using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using TK_Project.Application.CQRS.Order.Commands.AddOrder;
using TK_Project.Application.CQRS.Product.Commands.AddProduct;
using TK_Project.Application.Interfaces.Repositories.Order;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.WebUI.Models;
namespace TK_Project.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        IMediator _mediator;
        public OrderController(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IMediator mediator, IProductReadRepository productReadRepository, IUserReadRepository userReadRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _mediator = mediator;
            _productReadRepository = productReadRepository;
            _userReadRepository = userReadRepository;
        }
        public async Task <IActionResult> OrderList()
        {
            var data = await _orderReadRepository.GetAllAsync();
            var allData = await _orderReadRepository.GetOrderWithProductandUser();
            return View(allData);
        }
        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderVM order)
        {
            decimal total = 0;
            List<int> productIdList = new List<int>();
            //split product id's
            string[] productIds = order.Products.Split(',');
            foreach (var item in productIds)
            {
                productIdList.Add(Convert.ToInt32(item));
            }
            //all product information
            var productList = await _productReadRepository.GetProductsOfOrder(productIdList);

            //total amount
            foreach (var item in productList)
            {
                total += (decimal)item.Price;
            }
            var user = await _userReadRepository.GetByIdAsync(order.UserID);
            
            //add order
            await _orderWriteRepository.AddAsync(new Domain.Entities.Order
            {
                Payment_Status = order.Payment_Status,
                Date = order.Date,
                User = user,
                Amount = total,
                Products = productList
            });
            return RedirectToAction("OrderList", "Order");
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
            return RedirectToAction("OrderList", "Order");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderWriteRepository.DeleteByIDAsync(id);
            return RedirectToAction("OrderList", "Order");
        }
    }
}