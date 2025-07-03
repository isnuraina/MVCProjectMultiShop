using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Context;
using MultiShopProject.Models.Entities;

namespace MultiShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext context;
        public CategoryController(DataContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var category = context.Categories.ToList();
            return View(category);
        }
        public IActionResult Create()
        {         
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Details(int id)
        {
            var model = context.Categories.FirstOrDefault(m => m.Id == id);
            if (model == null)
            {
                return BadRequest();
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = context.Categories.FirstOrDefault(m => m.Id == id);
            if (model == null)
            {
                return BadRequest();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var entityModel = context.Categories.FirstOrDefault(m => m.Id == category.Id);
            if (entityModel == null)
            {
                return NotFound();
            }
            entityModel.Name = category.Name;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = context.Categories.FirstOrDefault(m => m.Id == id);
            if (model ==null)
            {
                return Json(
                    new
                    {
                        error = true,
                        message = "Qeyd movcud deyil"
                    });
            }
            context.Categories.Remove(model);
            context.SaveChanges();
            return Json(
                   new
                   {
                       error = false,
                       message = "Qeyd silindi!"
                   });
        }
    }
}
