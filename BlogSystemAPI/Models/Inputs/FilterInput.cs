using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Models.Inputs
{
    public class FilterInput
    {
        public int? UserId { get; set; }
        public string ContentContains { get; set; } = "";
        public bool OrderByCreateDateDesc { get; set; } = false;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
