using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using myClothWebShopAPI.Data;
using myClothWebShopAPI.Models;
using myClothWebShopAPI.Models.Dto_Models;

namespace myClothWebShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db )
        {
            _response = new();
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCart (string userId)
        {
            Cart cart = _db.Carts.Include(x => x.CartItems)
                    .ThenInclude(x => x.ShopItem)
                    .FirstOrDefault(x => x.UserId == userId);


              if (cart == null)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "UserId not exist or it doesn't have cart" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                 }

            if (cart.CartItems != null)
            {
                cart.TotalCost = cart.CartItems.Sum(x => x.Quantity * x.ShopItem.Price);
            }

                _response.Result = cart;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
                                        
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateItemInCart(string userId, int shopItemId, int updateQuantityBy)
        {
            ShopItem shopItem =  _db.ShopItems.FirstOrDefault(x => x.Id == shopItemId);

            if (shopItem == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            Cart cart =  _db.Carts.Include(x => x.CartItems).FirstOrDefault(x => x.UserId == userId);
            
            if(cart == null && updateQuantityBy > 0)
            {
                Cart newCart = new Cart() {UserId = userId,};               

                _db.Carts.Add(newCart);
                _db.SaveChanges();


                CartItem newCartItem = new CartItem
                {
                    ShopItemId = shopItemId,
                    CartId = newCart.Id,
                    Quantity = updateQuantityBy,
                    ShopItem = null
                };

                _db.CartItems.Add(newCartItem);
                _db.SaveChanges();

                _response.Result = cart;
                _response.StatusCode = HttpStatusCode.OK;

            }
            else
            {
                CartItem cartItemInCart = cart.CartItems.FirstOrDefault(x => x.ShopItemId == shopItemId);

                if (cartItemInCart == null) // если такого товара нету
                {
                    CartItem newCartItem = new CartItem()
                    {
                        ShopItemId = shopItemId,
                        CartId = cart.Id,
                        Quantity = updateQuantityBy,
                        ShopItem = null
                    };
                    _db.CartItems.Add(newCartItem);
                    _db.SaveChanges();

                    _response.Result = cart;
                    _response.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    // если есть то обновляем его количество
                    int newQuantity = cartItemInCart.Quantity + updateQuantityBy;

                    if (updateQuantityBy == 0 || newQuantity <= 0) // если число обновляемых товаров 0
                    {
                        _db.CartItems.Remove(cartItemInCart);
                        if (cart.CartItems.Count() == 1)
                        {
                            _db.Carts.Remove(cart);
                        }
                        _db.SaveChanges();

                        _response.Result = cart;
                        _response.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        cartItemInCart.Quantity = newQuantity;
                        _db.SaveChanges();

                        _response.Result = cart;
                        _response.StatusCode = HttpStatusCode.OK;
                    }
                }
            }
            return Ok(_response);



        }


        

    }
}
