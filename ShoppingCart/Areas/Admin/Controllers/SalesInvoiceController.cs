using Microsoft.AspNetCore.Mvc;

using ShoppingCart.Models;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalesInvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SalesInvoiceController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
