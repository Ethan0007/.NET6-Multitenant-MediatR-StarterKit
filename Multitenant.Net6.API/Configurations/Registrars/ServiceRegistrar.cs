using Multitenant.Net6.Domain.Repository;
using Multitenant.Net6.Domain.Tenant;

namespace Multitenant.Net6.API.Configurations.Registrars
{
    public class ServiceRegistrar : IRegistrar
    {
        public void RegistrarService(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("TenantSettings");
            services.Configure<TenantSettings>(appSettingsSection);

            services.Scan(scan => scan
                             .FromAssemblies(
                                 typeof(IService).Assembly)
                             .AddClasses()
                             .AsImplementedInterfaces());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers().AddNewtonsoftJson();
        }
    }
}
