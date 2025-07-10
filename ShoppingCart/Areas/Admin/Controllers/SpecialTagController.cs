using Microsoft.AspNetCore.Mvc;

using ShoppingCart.Models;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SpecialTagController(ApplicationDbContext context)
        {    
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.SpecialTags.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if(id== 0)
                return View(new SpecialTag() );
        else
                return View(_context.SpecialTags.Find(id));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(SpecialTag specialTag)
        {
            if(ModelState.IsValid)
            {
                if(specialTag.Id==0)
                    _context.SpecialTags.Add(specialTag);
                else
                    _context.SpecialTags.Update(specialTag);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(specialTag);
        }
        public IActionResult Delete(int id)
        {
            var specialTag=_context.SpecialTags.Find(id);
            _context.SpecialTags.Remove(specialTag);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
