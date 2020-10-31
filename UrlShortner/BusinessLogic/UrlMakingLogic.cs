using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Contracts.Dto.Requests;
using UrlShortner.Contracts.Dto.Response;
using UrlShortner.Services;

namespace UrlShortner.BusinessLogic
{
    public class UrlMakingLogic
    {
        private readonly IUrlService urlService;

        /// <summary>
        /// Use Random class for generate unique short code
        /// </summary>
        private Random random = new Random();

        // Set prefix for shortUrl
        private string shortUrl = "https://localhost:44369/search/";
        
        public UrlMakingLogic(IUrlService urlService)
        {
            this.urlService = urlService;
        }

        /// <summary>
        /// Make Short Url
        /// </summary>
        /// <param name="requestData">Url Shortening request dto</param>
        /// <returns>Url Shortening response dto</returns>
        public async Task<UrlShorteningResponse> MakeShortUrl(UrlShorteningRequest requestData)
        {
            // Generate unique short code of 7 characters
            string shortCode = await GenerateUniqueShortCode(7);

            // Save short url and long url data in database
            bool isCreated = await urlService.CreateUrlDataAsync(new Domain.tbl_urldata
            {
                ShortUrl = shortCode,
                LongUrl = requestData.url,
                NumberOfTimes = requestData.numberOfTimes,
                ExpireDate = requestData.expireDate,
                Status = (byte)Enum.UrlStatus.Active,
                CreateDate = DateTime.UtcNow
            });

            // Make the response
            return new UrlShorteningResponse
            {
                shortUrl = this.shortUrl + shortCode,
                longUrl = requestData.url
            };
        }

        /// <summary>
        /// Generate Unique Short Code
        /// </summary>
        /// <param name="length">Represent the Length of short Code</param>
        /// <returns>Unique Short Code</returns>
        private async Task<string> GenerateUniqueShortCode(int length)
        {
            string shortCode = string.Empty;
            bool isNotUnique = false;

            while (isNotUnique == false)
            {
                shortCode = GenerateAlphaNumeric(length);
                isNotUnique = await this.ValidateShortCode(shortCode);
            }
            return shortCode;
        }


        /// <summary>
        /// Validate short code is unique in database table
        /// </summary>
        /// <param name="shortCode">ShortCode</param>
        /// <returns></returns>
        private async Task<bool> ValidateShortCode(string shortCode)
        {
            // Get Url data by short code from table
            var data = await this.urlService.GetUrlDataByShortCodeAsync(shortCode);

            // Return the response data is found or nto
            return (data == null);
        }


        /// <summary>
        /// Generate unique short code of exact length
        /// </summary>
        /// <param name="length">Length of the short code</param>
        /// <returns>Unique Short Code</returns>
        private string GenerateAlphaNumeric(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
