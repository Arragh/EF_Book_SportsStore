using EF_Book_SportsStore.Models;
using EF_Book_SportsStore.Models.Pages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_SportsStore.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepository repository;
        public CategoriesController(ICategoryRepository repository) => this.repository = repository;

        public IActionResult Index(QueryOptions options) => View(repository.GetCategories(options));

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            repository.AddCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(Guid categoryId)
        {
            ViewBag.EditId = categoryId;
            return View("Index", repository.Categories);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            repository.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            repository.DeleteCategory(category);
            return RedirectToAction("Index");
        }
    }
}
