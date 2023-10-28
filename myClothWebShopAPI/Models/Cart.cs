using System.ComponentModel.DataAnnotations.Schema;

namespace myClothWebShopAPI.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string StripeId { get; set; }
        public string ClientSecret { get; set; }
        public List<CartItem> CartItems { get; set;} // есть такая таблица в бд поэтому свзь
      
        public double TotalCost { get; set; }
    }
}
