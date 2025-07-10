using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShoppingCart.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Product Product { get; set; }
      
        public int Quentity { get; set; }
    }
}
