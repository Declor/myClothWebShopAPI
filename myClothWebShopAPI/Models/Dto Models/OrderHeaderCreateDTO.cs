using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myClothWebShopAPI.Models.Dto_Models
{
    public class OrderHeaderCreateDTO
    {
        
        [Required]
        public string PickUpName { get; set; }
        [Required]
        public string PickupPhoneNumber { get; set; }
        [Required]
        public string PickupEmail { get; set; }

        public string ApplicationUserId { get; set; }
        public double OrderTotal { get; set; }

        public string StripeID { get; set; }
        public string Status { get; set; }
        public int TotalItems { get; set; }

        public List<OrderDetailsCreateDTO> OrderDetailsDTO { get; set; }
    }
}
