using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortner.Contracts.V1;
using UrlShortner.Contracts.Dto.Requests;
using UrlShortner.BusinessLogic;
using UrlShortner.Services;
using UrlShortner.Contracts.Dto.Response;

namespace UrlShortner.Controllers
{
    [Produces("application/json")]
    public class UrlShorteningController : Controller
    {
        private readonly IUrlService urlService;
        public UrlShorteningController(IUrlService urlService)
        {
            this.urlService = urlService;
        }


        /// <summary>
        /// Make Short Url API
        /// </summary>
        /// <param name="requestData">Url shortening request dto</param>
        /// <returns>Url shortening response dto</returns>
        [HttpPost(ApiRoutes.UrlShortening.Make)]
        public async Task<IActionResult> MakeUrlShort([FromBody]UrlShorteningRequest requestData)
        {
            // Object for creating short url
            UrlMakingLogic urlMakingLogic = new UrlMakingLogic(this.urlService);
            UrlShorteningResponse response = await urlMakingLogic.MakeShortUrl(requestData);
            return Ok(response);
        }
    }
}
