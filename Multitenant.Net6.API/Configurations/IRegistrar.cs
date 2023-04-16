namespace Multitenant.Net6.API.Configurations
{
    public interface IRegistrar
    {
        void RegistrarService(IServiceCollection services, IConfiguration configuration);
    }
}
