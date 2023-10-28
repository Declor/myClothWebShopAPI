using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myClothWebShopAPI.Models.Dto_Models
{
    public class OrderHeaderUpdateDTO
    {
        public int OrderHeaderId { get; set; }
        public string PickUpName { get; set; }
        public string PickupPhoneNumber { get; set; }
        public string PickupEmail { get; set; }

        public string StripeID { get; set; }
        public string Status { get; set; }
        public int TotalItems { get; set; }

    }
}
