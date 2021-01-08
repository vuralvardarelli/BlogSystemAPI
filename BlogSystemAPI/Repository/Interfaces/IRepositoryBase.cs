using BlogSystemAPI.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Repository.Interfaces
{
    /// <summary>
    /// Base Repository Interface For Crud Ops
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity">Post entity without id</param>
        /// <returns>inserted post</returns>
        Task<T> Insert(T entity);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">Updating the post</param>
        /// <returns>void</returns>
        Task Update(T entity);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">Deleting post with this id</param>
        /// <returns>void</returns>
        Task Delete(int id);

        /// <summary>
        /// Get All Posts
        /// </summary>
        /// <returns>All posts as a list</returns>
        Task<List<T>> GetAll();

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id">Gets post by this id</param>
        /// <returns>Post object</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Getting Posts By Filters
        /// </summary>
        /// <param name="filters">filters to include</param>
        /// <returns>List of filtered posts</returns>
        Task<List<T>> GetFilteredList(FilterInput filters);
    }
}
