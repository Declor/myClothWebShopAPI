using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Net;
using myClothWebShopAPI.Data;
using myClothWebShopAPI.Models;

namespace myClothWebShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private ApiResponse _response;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public PaymentController(IConfiguration configuration,ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
            _response = new ApiResponse();
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment(string userId)
        {
            Cart cart = _db.Carts
                .Include(x => x.CartItems)
                .ThenInclude(x => x.ShopItem).FirstOrDefault(x => x.UserId == userId);

            if (cart == null ||cart.CartItems == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            #region 

            StripeConfiguration.ApiKey = _configuration.GetValue<string>("DeveloperSettings:StripeKey");
            double cartTotalPrice = cart.CartItems.Sum(x => x.Quantity * x.ShopItem.Price);

            PaymentIntentCreateOptions options = new PaymentIntentCreateOptions
            {
                Amount = (int)(cartTotalPrice * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                {
                   "card",
                },
            };
            PaymentIntentService service = new PaymentIntentService();
            var response = service.Create(options);
            cart.StripeId = response.Id;
            cart.ClientSecret = response.ClientSecret;

            #endregion
            _response.Result = cart;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }

    }
}
