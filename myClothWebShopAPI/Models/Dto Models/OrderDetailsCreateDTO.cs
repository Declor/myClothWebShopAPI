using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myClothWebShopAPI.Models.Dto_Models
{
    public class OrderDetailsCreateDTO
    {                
        [Required]
        public int ShopItemId { get; set; }        
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
