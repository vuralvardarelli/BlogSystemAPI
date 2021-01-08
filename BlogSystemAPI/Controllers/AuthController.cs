using BlogSystemAPI.Models.Database;
using BlogSystemAPI.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Controllers
{
    /// <summary>
    /// Auth operation controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        /// <summary>
        /// Auth controller constructor
        /// </summary>
        /// <param name="userService"></param>
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Username 'kaizen' , Password '1234' will do the job for now
        /// </summary>
        /// <param name="userParam">Filling username and password is enough</param>
        /// <returns>User with a token to use for other endpoints</returns>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
