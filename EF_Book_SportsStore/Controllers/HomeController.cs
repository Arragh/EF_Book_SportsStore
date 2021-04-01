using EF_Book_SportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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

        public IActionResult Index() => View(repository.Products);

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

        //[HttpPost]
        //public IActionResult AddProduct(Product product)
        //{
        //    repository.AddProduct(product);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult UpdateProduct(Guid productId) => View(repository.GetProduct(productId));

        //[HttpPost]
        //public IActionResult UpdateProduct(Product product)
        //{
        //    repository.UpdateProduct(product);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult UpdateAll()
        //{
        //    ViewBag.UpdateAll = true;
        //    return View("Index", repository.Products);
        //}

        //[HttpPost]
        //public IActionResult UpdateAll(Product[] products)
        //{
        //    repository.UpdateAll(products);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
