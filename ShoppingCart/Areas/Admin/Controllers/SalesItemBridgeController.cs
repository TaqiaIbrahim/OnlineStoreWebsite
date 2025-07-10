using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalesItemBridgeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SalesItemBridgeController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
