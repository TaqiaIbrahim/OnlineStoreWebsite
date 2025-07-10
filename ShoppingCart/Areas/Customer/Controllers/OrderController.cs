using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Utility;

namespace ShoppingCart.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Checkout()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order order)
        {
            List<Product> products = HttpContext.Session.GetObject<List<Product>>("products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetail orderDetails = new OrderDetail();
                    orderDetails.ProductId = product.Id;
                    order.OrderDetails.Add(orderDetails);

                }
            }
            order.OrderNo=GetOrderNo();
            _context.Orders.Add(order);
           await  _context.SaveChangesAsync();
          
            HttpContext.Session.Set("products", null);
            return View();

        }
        public string GetOrderNo()
        {
           int rowCount = _context.Orders.ToList().Count+1;
            return rowCount.ToString("000");
        }
    }
}
