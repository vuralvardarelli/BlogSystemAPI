using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Models
{
    /// <summary>
    /// Result object to Return for APIS
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Status 0 or 1
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// Success or Error Message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Data object if any data needed
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; } = new object();
    }
}
