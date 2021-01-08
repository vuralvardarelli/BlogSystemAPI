using BlogSystemAPI.Models;
using BlogSystemAPI.Models.Database;
using BlogSystemAPI.Models.Inputs;
using BlogSystemAPI.Repository.Interfaces;
using BlogSystemAPI.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Controllers
{
    /// <summary>
    /// Blog CRUD operations
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private IPostRepository _postRepository;

        /// <summary>
        /// Blog controller constructor
        /// </summary>
        /// <param name="postRepository"></param>
        public BlogController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /// <summary>
        /// Adding a new post 
        /// </summary>
        /// <param name="input">Including only CONTENT will be enough. Other params will be automated by the system</param>
        /// <returns>Json object including last added Post</returns>
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
                Log.Information("Post inserted by user id : " + userId);
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
                Log.Error(ex, "Insert");
            }

            return rslt;
        }

        /// <summary>
        /// Updating the existing post
        /// </summary>
        /// <param name="input">Can update UserId and UpdateDate automated, also lets u change the CONTENT</param>
        /// <returns>Json object with error or success</returns>
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
                Log.Information("Post updated by user id : " + userId);
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
                Log.Error(ex, "Update");
            }

            return rslt;
        }

        /// <summary>
        /// Deleting existing post by Id
        /// </summary>
        /// <param name="postId">Post Id</param>
        /// <returns>Json object with error or success</returns>
        [HttpDelete("Delete")]
        public async Task<Result> Delete(string postId)
        {
            Result rslt = new Result();

            var userId = this.User.Identities.Select(x => x.Name).FirstOrDefault();

            try
            {
                await _postRepository.Delete(Convert.ToInt32(postId));
                rslt.Status = 1;
                rslt.Message = "Success";

                Log.Information("Post deleted by user id : " + userId);
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
                Log.Error(ex, "Delete");
            }

            return rslt;
        }

        /// <summary>
        /// Gets existing post by its own Id
        /// </summary>
        /// <param name="postId">Post Id</param>
        /// <returns>Json object with a desired post</returns>
        [HttpGet("Get")]
        public async Task<Result> Get(string postId)
        {
            Result rslt = new Result();

            try
            {
                rslt.Data = await _postRepository.GetById(Convert.ToInt32(postId));
                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
                Log.Error(ex, "Get");
            }

            return rslt;
        }

        /// <summary>
        /// Gets all of the posts inserted
        /// </summary>
        /// <returns>Json object with all of the posts</returns>
        [HttpGet("GetAll")]
        public async Task<Result> GetAll()
        {
            Result rslt = new Result();

            try
            {
                rslt.Data = await _postRepository.GetAll();
                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
                Log.Error(ex, "GetAll");
            }

            return rslt;
        }

        /// <summary>
        /// Gets filtered posts list
        /// </summary>
        /// <param name="filters">Object to filter anything</param>
        /// <returns>Json object with filtered list</returns>
        [HttpPost("FilteredList")]
        public async Task<Result> FilteredList([FromBody] FilterInput filters)
        {
            Result rslt = new Result();

            try
            {
                rslt.Data = await _postRepository.GetFilteredList(filters);
                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
                Log.Error(ex, "FilteredList");
            }

            return rslt;
        }
    }
}
