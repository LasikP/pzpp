using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nartyy.Models;
using System.Security.Claims;

namespace nartyy.Controllers
{
    [Route("user/[controller]")]
    [ApiController]
    public class UserController : Controller
    {


        //For admin Only
        [HttpGet]
        [Route("/user/Adminn")]
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        public IActionResult Adminn()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi you are an {currentUser.Roles}");
        }
        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Roles = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
