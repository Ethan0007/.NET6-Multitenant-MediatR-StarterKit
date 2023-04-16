namespace Multitenant.Net6.API.Configurations
{
    public static class IRegistrarExtensions
    {
        public static void ServiceRegistrarAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
                typeof(IRegistrar).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IRegistrar>().ToList();

            installers.ForEach(installer => installer.RegistrarService(services, configuration));
        }
    }
}
