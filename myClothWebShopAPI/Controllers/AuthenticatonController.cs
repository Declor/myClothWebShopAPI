using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using myClothWebShopAPI.Data;
using myClothWebShopAPI.Models;
using myClothWebShopAPI.Models.Dto_Models;
using myClothWebShopAPI.Utility;

namespace myClothWebShopAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticatonController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;

        public AuthenticatonController(ApplicationDbContext db,
            IConfiguration configuration, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _response = new ApiResponse();
            secretKey = configuration.GetValue<string>("DeveloperSettings:SecretKey"); 
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO register)
        {
       try
          {
                
            ApplicationUser userFromDb = _db.ApplicationUsers.FirstOrDefault(x=>
            x.UserName.ToUpper() == register.UserName.ToUpper());

            if (userFromDb != null) 
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;

                if (userFromDb.UserName == register.UserName)
                {
                    _response.ErrorMessages = new List<string> { "UserName or Email is already exist" };                
                }

                if (userFromDb.Email == register.Email)
                {
                    _response.ErrorMessages = new List<string> { "UserName or Email is already exist" };                    
                }

                return BadRequest(_response);
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = register.UserName,
                Email = register.Email,
                NormalizedEmail = register.Email.ToUpper(),
            };

            var result = await _userManager.CreateAsync(newUser, register.Password);

            if(result.Succeeded) 
            {
                await _userManager.AddToRoleAsync(newUser, CD.Customer_Role);
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
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            ApplicationUser userFromDb = _db.ApplicationUsers.FirstOrDefault(x =>
            x.UserName.ToUpper() == login.UserName.ToUpper());

            if (userFromDb == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { "Password or UserName is incorrect" };
                return BadRequest(_response);
            }

            bool isValidPasword = await _userManager.CheckPasswordAsync(userFromDb, login.Password);

            if (isValidPasword == false)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { "Password or UserName is incorrect" };                                       
                return BadRequest(_response);
            }
            
            var roles = await _userManager.GetRolesAsync(userFromDb);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(secretKey); //то выражение конвертирует строку secretKey в массив байтов (byte[]). Этот массив байтов представляет собой бинарное представление строки в кодировке ASCII.

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userName", userFromDb.UserName.ToString()),
                    new Claim("id", userFromDb.Id.ToString()),
                    new Claim("email", userFromDb.Email.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)  // определяет, как будет подписан токен. 
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponse loginResponse = new LoginResponse()
            {
                Token = tokenHandler.WriteToken(token),
            };

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);

        }


    }
}
