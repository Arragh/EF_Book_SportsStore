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

        public IActionResult Index()
        {
            return View();
        }
    }
}
