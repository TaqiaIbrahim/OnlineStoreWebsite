using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoppingCart.Models;
using ShoppingCart.Utility;
using System.Diagnostics;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Details(int id)
        {

            var product = _context.Products.Include(n => n.Category)
                .FirstOrDefault(c => c.Id == id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Details")]
        public IActionResult ProductDetails(int ?id)
        {
            List<Product> products = new List<Product>();

            var product = _context.Products.Include(n => n.Category)
                .FirstOrDefault(c => c.Id == id);

            products = HttpContext.Session.GetObject<List<Product>>("products");

            if (products == null)
            {
                products = new List<Product>();
            }
             products.Add(product);
            
            HttpContext.Session.SetObject("products", products);
            
            return View(product);
        }

        public IActionResult Cart(int id)
        {
            List<Product> products = HttpContext.Session.GetObject<List<Product>>("products");
            if(products == null)
            {
                products = new List<Product>();
            }
            return View(products);

        }
        public IActionResult Remove(int? id) {

            List<Product> products = HttpContext.Session.GetObject<List<Product>>("products");
            if (products != null)
            {
                var product=products.FirstOrDefault(c=>c.Id==id);
                if(product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.SetObject("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ActionName("Remove")]
        public IActionResult RemoveFromCart(int? id)
        {

            List<Product> products = HttpContext.Session.GetObject<List<Product>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.SetObject("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}