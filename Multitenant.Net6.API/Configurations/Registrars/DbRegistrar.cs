using Microsoft.EntityFrameworkCore;
using Multitenant.Net6.Domain.DatabaseContext;
using Multitenant.Net6.Domain.Tenant;
using Multitenant.Net6.Domain.Tenant.Services;

namespace Multitenant.Net6.API.Configurations.Registrars
{
    public class DbRegistrar : IRegistrar
    {
        public void RegistrarService(IServiceCollection services, IConfiguration configuration)
        {
            //var section = configuration.GetSection(nameof(TenantSettings));
            //var options = new TenantSettings();
            //section.Bind(options);

            //string conString = options.DefaultDb.ConnectionString!;

            //services.AddDbContext<AppDbContext>(options =>
            //options.UseSqlServer(conString));            
        }
    }
}
