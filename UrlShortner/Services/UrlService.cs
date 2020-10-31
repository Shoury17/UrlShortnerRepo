using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Contracts.Dto.Requests;
using UrlShortner.Domain;

namespace UrlShortner.Services
{
    public class UrlService : IUrlService
    {
        private readonly ApplicationDbContext dataContext;
        public UrlService(ApplicationDbContext _dataContext)
        {
            this.dataContext = _dataContext;
        }

        public async Task<tbl_urldata> GetUrlDataByShortCodeAsync(string shortCode)
        {
            return await this.dataContext.tbl_urldata.SingleOrDefaultAsync(x => x.ShortUrl == shortCode);
        }

        public async Task<bool> CreateUrlDataAsync(tbl_urldata urlAddData)
        {
            this.dataContext.tbl_urldata.Add(urlAddData);
            var added = await this.dataContext.SaveChangesAsync();
            return added > 0;
        }
    }
}
