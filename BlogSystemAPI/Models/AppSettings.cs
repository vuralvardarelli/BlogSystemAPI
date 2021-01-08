using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Models
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public bool Migrate { get; set; }
        public string AuthSecret { get; set; }
        public string PasswordHashSecret { get; set; }
    }
}
