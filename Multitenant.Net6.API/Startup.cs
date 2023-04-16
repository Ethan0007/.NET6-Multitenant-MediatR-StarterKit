/*
 * License: MIT
 * Author: Joever E. Monceda
 * Github: https://github.com/Ethan0007
*/
using Multitenant.Net6.API.Configurations;
using Multitenant.Net6.API.Extensions; 
using Multitenant.Net6.Domain.Tenant.Implementation;
using Multitenant.Net6.Domain.Tenant.Services;
using System.Globalization;

namespace Multitenant.Net6.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {

            services.AddSignalR();
            services.AddCors();
            services.AddEasyCaching(options =>
            {
                options.UseInMemory("multitenant");
            });
            services.ServiceRegistrarAssembly(_config);
            services.MigrateTenantDatabases(_config);
            services.AddTransient<ITenantService, TenantService>();
        }

        public void Configure(IApplicationBuilder app, IServiceCollection services)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-PH");
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            CultureInfo.DefaultThreadCurrentCulture = culture;
        }
    }
}
