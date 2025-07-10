using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Product
    {
        public int Id { get; set; } 

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Display(Name = "SpecialTag")]
        public int SpecialTagId { get; set; }
        public SpecialTag SpecialTag { get; set; }
      
    }
}
