using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Models
{
    /// <summary>
    /// Application Settings from appsettings.json
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// DB Connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Migration enabled or disabled for app start.
        /// </summary>
        public bool Migrate { get; set; }

        /// <summary>
        /// Authentication secret to create token
        /// </summary>
        public string AuthSecret { get; set; }

        /// <summary>
        /// Password Secret to encrypt/decrypt passwords
        /// </summary>
        public string PasswordHashSecret { get; set; }
    }
}
