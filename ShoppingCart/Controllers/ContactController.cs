using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
