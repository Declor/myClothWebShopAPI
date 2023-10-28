using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using myClothWebShopAPI.Data;
using myClothWebShopAPI.Models;
using myClothWebShopAPI.Models.Dto_Models;
using myClothWebShopAPI.Utility;

namespace myClothWebShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders (string? userId)
        {            
            var orderHeaders = _db.OrderHeaders
                .Include(x => x.OrderDetails).ThenInclude(x => x.ShopItem);
            
            var headersOfUser = orderHeaders.Where(x => x.ApplicationUserId == userId);

            if (string.IsNullOrEmpty(userId) )
            {
                _response.Result = headersOfUser;
            }
            else
            {
                _response.Result = orderHeaders.Where(x => x.ApplicationUserId == userId);
            }

            return Ok(_response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrder(int id)
        {

            var orderHeader = _db.OrderHeaders
                .Include(x => x.OrderDetails).ThenInclude(x => x.ShopItem)
                .Where(x => x.OrderHeaderId == id);


            if (orderHeader == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            _response.Result = orderHeader;
            _response.StatusCode = HttpStatusCode.OK;
            

            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderHeaderCreateDTO orderHeaderDTO)
        {
            if (ModelState.IsValid)
            {

            OrderHeader order = new OrderHeader()
            {
                ApplicationUserId = orderHeaderDTO.ApplicationUserId,
                PickupEmail = orderHeaderDTO.PickupEmail,
                PickUpName = orderHeaderDTO.PickUpName,
                PickupPhoneNumber = orderHeaderDTO.PickupPhoneNumber,
                OrderTotal = orderHeaderDTO.OrderTotal,
                OrderDate = DateTime.Now,
                StripeID = orderHeaderDTO.StripeID,
                TotalItems = orderHeaderDTO.TotalItems,
                Status = String.IsNullOrEmpty(orderHeaderDTO.Status) ? CD.status_pending : orderHeaderDTO.Status,
            };

            
            _db.OrderHeaders.Add(order);
            _db.SaveChanges();
            foreach (var orderDetailsDTO in orderHeaderDTO.OrderDetailsDTO)
            {
                    OrderDetails orderDetails = new()
                    {
                        OrderHeaderId = order.OrderHeaderId,
                        ItemName = orderDetailsDTO.ItemName,
                        ShopItemId = orderDetailsDTO.ShopItemId,
                        Price = orderDetailsDTO.Price,
                        Quantity = orderDetailsDTO.Quantity,
                    };
                    _db.OrderDetails.Add(orderDetails);
             }
            _db.SaveChanges();
            _response.Result = order;
            order.OrderDetails = null;
            _response.StatusCode = HttpStatusCode.Created;                
            }
            return Ok(_response);

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrderHeader (int id, [FromBody] OrderHeaderUpdateDTO orderHeaderUpdateDTO)
        {
            if (orderHeaderUpdateDTO == null || id != orderHeaderUpdateDTO.OrderHeaderId)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Id not match" };
                return BadRequest(_response);
            }

            OrderHeader orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.OrderHeaderId == id);

            if (orderFromDb == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if(!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickUpName))
            {
                orderFromDb.PickUpName = orderHeaderUpdateDTO.PickUpName;
            }
            if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickupPhoneNumber))
            {
                orderFromDb.PickupPhoneNumber = orderHeaderUpdateDTO.PickupPhoneNumber;
            }
            if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickupEmail))
            {
                orderFromDb.PickupEmail = orderHeaderUpdateDTO.PickupEmail;
            }
            if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.Status))
            {
                orderFromDb.Status = orderHeaderUpdateDTO.Status;
            }
            if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.StripeID))
            {
                orderFromDb.StripeID = orderHeaderUpdateDTO.StripeID;
            }
            _response.Result = orderFromDb;
            _db.SaveChanges();
            return Ok(_response);

        }
    }
}
