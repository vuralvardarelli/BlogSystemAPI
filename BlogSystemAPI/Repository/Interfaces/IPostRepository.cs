using BlogSystemAPI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Repository.Interfaces
{
    /// <summary>
    /// Post Repository Interface
    /// </summary>
    public interface IPostRepository : IRepositoryBase<Post>
    {
    }
}
