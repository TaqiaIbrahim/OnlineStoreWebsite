using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShoppingCart.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[JsonIgnore]
        //[IgnoreDataMember]
        public ICollection<Product> Products { get; set;}
 
    }
}
