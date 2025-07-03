using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            return View();
        }
    }
}
