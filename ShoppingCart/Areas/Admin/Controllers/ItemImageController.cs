using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemImageController(ApplicationDbContext context)
        {     
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
