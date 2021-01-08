using BlogSystemAPI.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Data
{
    /// <summary>
    /// DB Context EFCore
    /// </summary>
    public class BlogDBContext : DbContext
    {
        /// <summary>
        /// BlogDBContext Constructor
        /// </summary>
        /// <param name="dbOptions"></param>
        public BlogDBContext(DbContextOptions<BlogDBContext> dbOptions)
            : base(dbOptions)
        {
        }

        /// <summary>
        /// Posts rows
        /// </summary>
        public DbSet<Post> Posts { get; set; }

        /// <summary>
        /// Users rows
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
