using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myClothWebShopAPI.Models
{
    public class ShopItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public double Price { get ; set;  }
        [Required]
        public string Image { get; set; }
       
        public string Base64Image { get; set; }
        
    }
}
