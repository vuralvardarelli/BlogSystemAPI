using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Models.Inputs
{
    /// <summary>
    /// FilterInput
    /// </summary>
    public class FilterInput
    {
        /// <summary>
        /// UserId filter
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// ContentContains filter
        /// </summary>
        public string ContentContains { get; set; } = "";

        /// <summary>
        /// OrderByCreateDateDesc filter
        /// </summary>
        public bool OrderByCreateDateDesc { get; set; } = false;

        /// <summary>
        /// StartDate filter
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate filter
        /// </summary>
        public DateTime? EndDate { get; set; }

    }
}
