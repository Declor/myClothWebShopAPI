using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Net;
using System.Net.Http.Headers;
using myClothWebShopAPI.Data;
using myClothWebShopAPI.Models;
using myClothWebShopAPI.Models.Dto_Models;
using static System.Net.WebRequestMethods;

namespace myClothWebShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string pathToProject;
        public ShopItemController(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _response = new ApiResponse();
            pathToProject = webHostEnvironment.ContentRootPath;
        }

             
        [HttpGet]
        public async Task<IActionResult> GetShopItems()
        {
            try
            {

                ShopItem[] shopItems = _db.ShopItems.AsNoTracking().ToArray();

                _response.Result = shopItems;

                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string> { ex.Message };

               
            }
            return BadRequest(_response);
        }


        [HttpGet("{id:int}", Name = "GetShopItem")]
        public async Task<IActionResult> GetShopItem(int id)
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            ShopItem shopItem = _db.ShopItems.FirstOrDefault(x => x.Id == id);

            

            if (shopItem == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound();
            }



            _response.Result = shopItem;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopItem([FromForm] ShopItemCreateDTO shopItemCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (shopItemCreateDTO == null || shopItemCreateDTO.File.Length == 0)
                    {
                        if (shopItemCreateDTO.File.Length == 0)
                        {
                            _response.ErrorMessages = new List<string>
                            {
                                "Image is required to create a new shop item"
                            };
                        }
                        return BadRequest(_response);
                    }

                    string fileName = $"{Guid.NewGuid()}" +
                        $"{Path.GetExtension(shopItemCreateDTO.File.FileName)}";

                    string pathToShopItemsImages = pathToProject + @"\images\shopItems\";

                    string imagePath = pathToShopItemsImages + fileName;

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        shopItemCreateDTO.File.CopyTo(fileStream);
                    }                    

                    ShopItem shopItem = new ShopItem();

                    shopItem.Name = shopItemCreateDTO.Name ?? "";
                    shopItem.Price = shopItemCreateDTO.Price;
                    shopItem.Description = shopItemCreateDTO.Description?? "";
                    shopItem.Category = shopItemCreateDTO.Category ?? "";

                    shopItem.Image = imagePath;

                    byte[] imageBytes = System.IO.File.ReadAllBytes(shopItem.Image); // // Функция System.IO.File.ReadAllBytes читает содержимое файла и возвращает его в виде массива байтов (byte[]).

                    string base64Image = Convert.ToBase64String(imageBytes);    //// эта строка кода преобразует эти байты в строку в кодировке base64. Кодировка base64 представляет бинарные данные в виде текстовой строки, состоящей из ASCII-символов, что удобно для передачи данных, таких как изображения, в текстовых форматах.

                    shopItem.Base64Image = base64Image;

                    _db.ShopItems.Add(shopItem);
                    await _db.SaveChangesAsync();


                    _response.Result = shopItem;
                    _response.StatusCode = HttpStatusCode.Created;

                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;

                _response.ErrorMessages = new List<string>
                {
                    ex.Message
                };
                return BadRequest(_response);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateShopItem(int id, [FromForm] ShopItemCreateDTO shopItemUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (shopItemUpdateDTO == null || id != shopItemUpdateDTO.Id)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        return BadRequest(_response);
                    }

                    ShopItem shopItemFromDb = await _db.ShopItems
                        .FirstOrDefaultAsync(x => x.Id == id);

                    if (shopItemFromDb == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        return BadRequest(_response);
                    }

                    shopItemFromDb.Name = shopItemUpdateDTO.Name ?? "";
                    shopItemFromDb.Description = shopItemUpdateDTO.Description ?? "";
                    shopItemFromDb.Category = shopItemUpdateDTO.Category ?? "";
                    shopItemFromDb.Price = shopItemUpdateDTO.Price;


                    if (shopItemUpdateDTO.File!=null)
                    {
                        string filePath = shopItemFromDb.Image;

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }

                        shopItemFromDb.Image = null;

                        string fileName = $"{Guid.NewGuid()}" +
                            $"{Path.GetExtension(shopItemUpdateDTO.File.FileName)}";

                        string pathToShopItemsImages = pathToProject + @"\images\shopItems\";

                        string imagePath = pathToShopItemsImages + fileName;

                        using (var fileStream = new FileStream(imagePath, FileMode.Create))
                        {
                            shopItemUpdateDTO.File.CopyTo(fileStream);
                        }

                        shopItemFromDb.Image = imagePath;
                        
                        byte[] imageBytes = System.IO.File.ReadAllBytes(shopItemFromDb.Image); // // Функция System.IO.File.ReadAllBytes читает содержимое файла и возвращает его в виде массива байтов (byte[]).

                        string base64Image = Convert.ToBase64String(imageBytes);    //// эта строка кода преобразует эти байты в строку в кодировке base64. Кодировка base64 представляет бинарные данные в виде текстовой строки, состоящей из ASCII-символов, что удобно для передачи данных, таких как изображения, в текстовых форматах.

                        shopItemFromDb.Base64Image = base64Image;
                    }

                    _db.ShopItems.Update(shopItemFromDb);
                    await _db.SaveChangesAsync();

                    _response.Result = shopItemFromDb;
                    _response.StatusCode = HttpStatusCode.Created;

                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;

                _response.ErrorMessages = new List<string>
                {
                    ex.Message
                };
                return BadRequest(_response);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteShopItem(int id)
        {
            try
            {
                
                    if (id == 0)
                    {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                    }

                    ShopItem shopItemFromDb = await _db.ShopItems
                        .FirstOrDefaultAsync(x => x.Id == id);

                    if (shopItemFromDb == null)
                    {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                    }

                    string filePath = shopItemFromDb.Image;

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    _db.ShopItems.Remove(shopItemFromDb);
                    await _db.SaveChangesAsync();

                    _response.StatusCode = HttpStatusCode.OK;

                    return Ok(_response);
                
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                return BadRequest(_response);
            }
        }

    }
}