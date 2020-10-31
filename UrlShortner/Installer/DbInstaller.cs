using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Domain;

namespace UrlShortner.Installer
{
    /// <summary>
    /// Db installer
    /// </summary>
    public class DbInstaller : IInstaller
    {
        /// <summary>
        ///  Install all DB related services
        /// </summary>
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
