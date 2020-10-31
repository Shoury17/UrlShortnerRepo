using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UrlShortner.Contracts.Dto.Requests
{
    /// <summary>
    /// Request DTO for Url shortening
    /// </summary>
    public class UrlShorteningRequest
    {
        /// <summary>
        /// Represent the url which will be short
        /// </summary>
        [Required]
        public string url { get; set; }

        /// <summary>
        /// Represent the number of times short url can be used
        /// </summary>
        public Nullable<int> numberOfTimes { get; set; }

        /// <summary>
        /// Represent the expiredate of shorturl
        /// </summary>
        public Nullable<DateTime> expireDate { get; set; }
    }
}
