using ShoppingCart.Models;

namespace ShoppingCart.ViewModel
{
    public class FormViewModel
    {
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<SpecialTag> specialTags { get; set; }
    }
}
