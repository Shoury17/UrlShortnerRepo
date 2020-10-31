using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortner.Contracts.Dto.Response
{
    /// <summary>
    /// Response DTO when short code is found
    /// </summary>
    public class UrlSearchResponse
    {
        /// <summary>
        /// Represent the short code is found or not
        /// </summary>
        public bool isFound { get; set; }

        /// <summary>
        /// Represent the long url 
        /// </summary>
        public string longUrl { get; set; }
    }
}
