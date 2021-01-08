using BlogSystemAPI.Models;
using BlogSystemAPI.Models.Database;
using BlogSystemAPI.Models.Inputs;
using BlogSystemAPI.Repository.Interfaces;
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
        private IPostRepository _postRepository;

        public BlogController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost("InsertPost")]
        public async Task<Result> InsertPost([FromBody] PostInput input)
        {
            Result rslt = new Result();

            string userId = this.User.Identities.Select(x=>x.Name).FirstOrDefault();

            try
            {
                Post post = new Post()
                {
                    Content = input.Content,
                    UserId = string.IsNullOrEmpty(userId) ? -1 : Convert.ToInt32(userId),
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                rslt.Data = await _postRepository.Insert(post);
                rslt.Status = 1;
                rslt.Message = "Success";             
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
            }

            return rslt;
        }
    }
}
