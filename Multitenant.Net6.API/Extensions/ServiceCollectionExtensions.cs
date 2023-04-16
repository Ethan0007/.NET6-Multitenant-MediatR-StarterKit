using Microsoft.EntityFrameworkCore;
using Multitenant.Net6.Domain.DatabaseContext;
using Multitenant.Net6.Domain.Tenant;
using Multitenant.Net6.Services.Constant;

namespace Multitenant.Net6.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection MigrateTenantDatabases(this IServiceCollection services, IConfiguration config)
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var section = configuration.GetSection(nameof(TenantSettings));
            var options = new TenantSettings();
            section.Bind(options);

            string defaultConnectionString = options.DefaultDb?.ConnectionString!;
            string defaultDbProvider = options.DefaultDb?.DBProvider!;

            if (defaultDbProvider.ToUpper() == DbProvider.MMSQL)
            { 
                services.AddDbContext<AppDbContext>(sql => sql.UseSqlServer(e =>
                    {
                        e.MigrationsAssembly("Multitenant.Net6.API");
                        e.EnableRetryOnFailure();
                        e.CommandTimeout(280);
                    }));
            }

            var tenants = options.Tenants;

            foreach (var tenant in tenants)
            {
                string connectionString;
                if (string.IsNullOrEmpty(tenant.ConnectionString))
                {
                    connectionString = defaultConnectionString;
                }
                else
                {
                    connectionString = tenant.ConnectionString;
                }
                using var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.SetConnectionString(connectionString);
                dbContext.Database.Migrate();
            }

            return services;
        }
    }
}
