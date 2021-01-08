using BlogSystemAPI.Data;
using BlogSystemAPI.Models.Database;
using BlogSystemAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private BlogDBContext _dbContext;

        public PostRepository(BlogDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(int id)
        {
            Post post = await _dbContext.Posts.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAll()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _dbContext.Posts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<Post> GetFilteredList()
        {
            throw new NotImplementedException();
        }

        public async Task<Post> Insert(Post entity)
        {
            await _dbContext.Posts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Posts.Where(x => x.Content == entity.Content && x.UserId == entity.UserId).LastOrDefaultAsync();
        }

        public async Task Update(Post entity)
        {
            Post post = await _dbContext.Posts.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            if (post == null)
                return;

            if (post.Content != entity.Content)
            {
                post.Content = entity.Content;
                post.UpdateDate = DateTime.Now;

                _dbContext.Posts.Update(post);
                await _dbContext.SaveChangesAsync();
            }
                
        }
    }
}
