using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
