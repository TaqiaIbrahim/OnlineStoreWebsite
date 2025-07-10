using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options):base(options)
        { 
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SpecialTag> SpecialTags { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<ShoppingCartItem> cartItems  { get; set;}
        
                
        
    }
}
