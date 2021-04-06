using EF_Book_SportsStore.Models;
using EF_Book_SportsStore.Models.Pages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// Add-Migration ИМЯ
// Update-Database

namespace EF_Book_SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ICategoryRepository categoryRepository;
        public HomeController(IRepository repository, ICategoryRepository categoryRepository)
        {
            this.repository = repository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index(QueryOptions options) => View(repository.GetProducts(options));

        public IActionResult UpdateProduct(Guid productId)
        {
            ViewBag.Categories = categoryRepository.Categories;
            return View(productId == default(Guid) ? new Product() : repository.GetProduct(productId));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (product.ProductId == default(Guid))
            {
                repository.AddProduct(product);
            }
            else
            {
                repository.UpdateProduct(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
