using Multitenant.Net6.Domain.DatabaseContext;
using Multitenant.Net6.Domain.Entity;
using Multitenant.Net6.Domain.Repository;
using Multitenant.Net6.Infa.Services;
using System.Reflection;

namespace Multitenant.Net6.API.Configurations.Registrars
{
    public class RepositoryRegistrar : IRegistrar
    {
        public void RegistrarService(IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IRepository<>), typeof(Repository<>))
                .AddClasses()
                .AsImplementedInterfaces());
        }
    }
}
