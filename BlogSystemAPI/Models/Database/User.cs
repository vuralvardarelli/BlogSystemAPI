using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Models.Database
{
    /// <summary>
    /// User Object/Table
    /// </summary>
    [Table("BLOG_USER")]
    public class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("SURNAME")]
        public string Surname { get; set; }

        [Required]
        [Column("USERNAME")]
        public string Username { get; set; }

        [Required]
        [Column("PASSWORD")]
        public string Password { get; set; }

        [Column("TOKEN")]
        public string Token { get; set; }
    }
}
