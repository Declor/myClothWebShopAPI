using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myClothWebShopAPI.Utility;

namespace myClothWebShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSomething()
        {
            return Ok("You are authenticated");
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = CD.Admin_Role)]

        public async Task<IActionResult> GetSomething(int someIntValue)
        {
            
            return Ok("You are ADMIN ! ! !");
        }
    }
}
