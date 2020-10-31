using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Contracts.Dto.Response;
using UrlShortner.Services;

namespace UrlShortner.BusinessLogic
{
    public class UrlSearchLogic
    {
        private readonly IUrlService urlService;

        public UrlSearchLogic(IUrlService urlService)
        {
            this.urlService = urlService;
        }

        /// <summary>
        /// Search long url using short Code
        /// </summary>
        /// <param name="shortCode">ShortCode</param>
        /// <returns>Response dto of Url Search</returns>
        public async Task<UrlSearchResponse> Search(string shortCode)
        {
            // Get url data from database table by shortcode
            var data = await this.urlService.GetUrlDataByShortCodeAsync(shortCode);

            // if data is null or status of url data is deactivated or number of times is equal to number of times used then send response isFound false
            if (data == null || data.Status == (byte)Enum.UrlStatus.DeActive || (data.NumberOfTimes != null && data.NumberOfTimesUsed != null && data.NumberOfTimes == data.NumberOfTimesUsed))
                return new UrlSearchResponse
                {
                    isFound = false
                };

            // Increase the number of times used
            data.NumberOfTimesUsed = (data.NumberOfTimesUsed == null) ? 1 : data.NumberOfTimesUsed++;
            // Update the data in database
            await this.urlService.UpdateUrlDataAsync(data);


            // Create the url search response
            return new UrlSearchResponse
            {
                isFound = true,
                longUrl = data.LongUrl
            };
        }
    }
}
