using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MultiShopProject.Context;
using MultiShopProject.Models.Entities;

namespace MultiShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;


        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products.Include(x => x.Category).ToList();
            return View(products);
        }

        public ProductController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product, IFormFile ImageFile)
        {
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Image is required");
            }


            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
                return View(product);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
            var filePath = Path.Combine(_env.WebRootPath, "img", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                ImageFile.CopyTo(stream);
            }

            product.ImageURL = fileName;

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var product = _context.Products.FirstOrDefault(m => m.Id == id);
            if (product is null)
            {
                return BadRequest();
            }
            return View(product);
        }




    }
}
