using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Domain;

namespace UrlShortner.Services
{
    public interface IUrlService
    {
        Task<tbl_urldata> GetUrlDataByShortCodeAsync(string shortCode);
        Task<bool> CreateUrlDataAsync(tbl_urldata urlAddData);
    }
}
