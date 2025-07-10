using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using ShoppingCart.ViewModel;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;  
        }
        public IActionResult Index()
        {
            return View(_context.Products.Include(c=>c.Category).Include(s=>s.SpecialTag).ToList());
        }
        public IActionResult AddOrEdit(int id)
        {

            var ViewModel = new FormViewModel()
            {
                categories = _context.Categories.ToList(),
                specialTags = _context.SpecialTags.ToList()
            };
            ViewBag.Category = ViewModel.categories.ToList();
            ViewBag.SpecialTag = ViewModel.specialTags.ToList();
            if (id == 0)
                return View(new Product());
            else    
            return View(_context.Products.Find(id));
        
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Product product, List<IFormFile> Files)
        {

           
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string Image = Guid.NewGuid().ToString() + ".jpg";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/uploads", Image);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(stream);
                    }
                    product.Image = Image;
                }
            }

            if (!ModelState.IsValid)
            {
               
                if (product.Id==0) 
                    _context.Products.Add(product);
                else
                    _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(n => n.Category).Include(m => m.SpecialTag).FirstOrDefault(c => c.Id == id);
            return View(product);
        }
            public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
