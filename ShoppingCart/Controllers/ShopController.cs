using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ShoppingCart.Models;
using ShoppingCart.Utility;
using ShoppingCart.ViewModel;

namespace ShoppingCart.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private List<ShoppingCartItem> _cartItems;
        public ShopController(ApplicationDbContext context)
        {  
            _context = context;
            _cartItems = new List<ShoppingCartItem>();
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Details(int id)
        {

            var product = _context.Products.Include(n => n.Category)
                .Include(m => m.SpecialTag).FirstOrDefault(c => c.Id == id);
            return View(product);
        }

        //[HttpPost]
        //[ActionName("Details")]
        //public IActionResult ProductDetails(int id)
        //{
        //    List<Product> products = new List<Product>();

        //    var product = _context.Products.Include(n => n.Category)
        //        .Include(m => m.SpecialTag).FirstOrDefault(c => c.Id == id);

        //    products = HttpContext.Session.GetObject<List<Product>>("products");

        //    if (products == null)
        //    {
        //        products = new List<Product>();
        //    }
        //    products.Add(product);
        //    HttpContext.Session.SetObject("products", products);
        //    return View(product);
        //}

        //public IActionResult Cart(int id)
        //{
        //    List<Product> products = new List<Product>();

        //    var product = _context.Products.Include(n => n.Category)
        //        .Include(m => m.SpecialTag).FirstOrDefault(c => c.Id == id);

        //    products = HttpContext.Session.GetObject<List<Product>>("products");

        //    if (products == null)
        //    {
        //        products = new List<Product>();
        //    }
        //    products.Add(product);
        //    HttpContext.Session.SetObject("products", products);
        //    //List<Product> products = HttpContext.Session.GetObject<List<Product>>("products");
        //    // if (products == null)
        //    // {
        //    //     products = new List<Product>();
        //    // }

        //    return View();
        //}
        
        public IActionResult AddToCart(int id)
        {
            var ProductToAdd = _context.Products.Include(n => n.Category).
                Include(m => m.SpecialTag).FirstOrDefault(c => c.Id == id);
            var cartItems = HttpContext.Session.GetObject<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var existingCarItem = _cartItems.FirstOrDefault(c => c.Product.Id == id);
            if (existingCarItem != null)
            {
                existingCarItem.Quentity++;
            }
            else
            {
                cartItems.Add(new ShoppingCartItem
            {
                Product = ProductToAdd,
                Quentity = 1,
            });
        }

        HttpContext.Session.SetObject("Cart", cartItems);
            return RedirectToAction("ViewCart");

        }
        
        public IActionResult ViewCart()
        {

            var cartItems = HttpContext.Session.GetObject<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var CartVM = new ShoppingCartVM
            {
                CartItems = cartItems,
              
                
                TotalPrice =0 /*cartItems.Sum(i => i.Product.Price * i.Quentity)*/,
                 
                TotalQuentity = 0 ,


            };
            return View(CartVM);
        }

    }
}
