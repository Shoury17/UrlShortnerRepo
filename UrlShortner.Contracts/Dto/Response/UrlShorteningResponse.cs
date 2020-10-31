using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortner.Contracts.Dto.Response
{
    /// <summary>
    /// Response DTO after Url is Short
    /// </summary>
    public class UrlShorteningResponse
    {
        /// <summary>
        /// Represent the short url
        /// </summary>
        public string shortUrl { get; set; }

        /// <summary>
        /// Represent the long url
        /// </summary>
        public string longUrl { get; set; }
    }
}
