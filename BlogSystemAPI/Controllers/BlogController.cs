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

        [HttpPost("Insert")]
        public async Task<Result> Insert([FromBody] PostInput input)
        {
            Result rslt = new Result();

            var userId = this.User.Identities.Select(x => x.Name).FirstOrDefault();

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

        [HttpPut("Update")]
        public async Task<Result> Update([FromBody] Post input)
        {
            Result rslt = new Result();

            var userId = this.User.Identities.Select(x => x.Name).FirstOrDefault();

            try
            {
                input.UserId = string.IsNullOrEmpty(userId) ? input.UserId : Convert.ToInt32(userId);

                await _postRepository.Update(input);
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

        [HttpDelete("Delete")]
        public async Task<Result> Delete(string postId)
        {
            Result rslt = new Result();

            try
            {
                await _postRepository.Delete(Convert.ToInt32(postId));
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
