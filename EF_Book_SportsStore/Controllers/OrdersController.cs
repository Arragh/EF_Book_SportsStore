using EF_Book_SportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_SportsStore.Controllers
{
    public class OrdersController : Controller
    {
        private IRepository productRepository;
        private IOrdersRepository ordersRepository;
        public OrdersController(IRepository productRepository, IOrdersRepository ordersRepository)
        {
            this.productRepository = productRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index() => View(ordersRepository.Orders);

        public IActionResult EditOrder(Guid orderId)
        {
            var products = productRepository.Products;
            Order order = orderId == default(Guid) ? new Order() : ordersRepository.GetOrder(orderId);
            IDictionary<Guid, OrderLine> linesMap = order.Lines?.ToDictionary(l => l.ProductId) ?? new Dictionary<Guid, OrderLine>();
            ViewBag.Lines = products.Select(p => linesMap.ContainsKey(p.ProductId) ? linesMap[p.ProductId] : new OrderLine { Product = p, ProductId = p.ProductId, Quantity = 0 });
            return View(order);
        }

        [HttpPost]
        public IActionResult AddUpdateOrder(Order order)
        {
            order.Lines = order.Lines.Where(l => l.OrderLineId != default(Guid) || (l.OrderLineId == default(Guid) && l.Quantity > 0)).ToArray();
            if (order.OrderId == default(Guid))
            {
                ordersRepository.AddOrder(order);
            }
            else
            {
                ordersRepository.UpdateOrder(order);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteOrder(Order order)
        {
            ordersRepository.DeleteOrder(order);
            return RedirectToAction("Index");
        }
    }
}
