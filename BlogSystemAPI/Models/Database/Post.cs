using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Models.Database
{
    [Table("BLOG_POST")]
    public class Post
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("USER_ID")]
        public int UserId { get; set; }

        [Column("CREATE_DATE")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Column("UPDATE_DATE")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        [Required]
        [Column("CONTENT")]
        public string Content { get; set; }
    }
}
