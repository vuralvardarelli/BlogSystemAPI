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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        [HttpGet("Test")]
        public async Task<string> Test()
        {
            return await Task.FromResult("hellö");
        }
    }
}
