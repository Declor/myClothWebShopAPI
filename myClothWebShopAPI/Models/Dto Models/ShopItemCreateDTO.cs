using System.ComponentModel.DataAnnotations;

namespace myClothWebShopAPI.Models.Dto_Models
{
    public class ShopItemCreateDTO
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
        public double Price { get; set; }
        public IFormFile File { get; set; }
    }
}
