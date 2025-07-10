using ShoppingCart.Models;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShoppingCart.ViewModel
{
    public class ShoppingCartVM
    {
        //[JsonIgnore]
        //[IgnoreDataMember]
        public List<ShoppingCartItem> CartItems { get; set; }
      
       
        public decimal? TotalPrice { get; set; }
        public decimal? TotalQuentity { get; set;}

    }
}
