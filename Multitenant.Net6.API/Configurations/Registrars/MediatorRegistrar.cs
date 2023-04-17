using MediatR;
using Multitenant.Net6.Application.Interface;

namespace Multitenant.Net6.API.Configurations.Registrars
{
    public class MediatorRegistrar : IRegistrar
    {
        public void RegistrarService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ServiceFactory>(p => p.GetService!);

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator), typeof(IMediatorHandler))
                .AddClasses()
                .AsImplementedInterfaces());

            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<IMediator>();
        }
    }
}
