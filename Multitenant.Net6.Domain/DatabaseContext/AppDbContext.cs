using Microsoft.EntityFrameworkCore;
using Multitenant.Net6.Domain.Entity;
using Multitenant.Net6.Domain.Tenant.Services;

namespace Multitenant.Net6.Domain.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        private string? _tenantId { get; set; }

        private readonly ITenantService _tenantService;

        public AppDbContext(DbContextOptions options, 
                            ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;

            _tenantId = _tenantService.GetTenantInfo()?.TenantId;
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasQueryFilter(a => a.TenantId == _tenantId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = _tenantService.GetConnectionString();

            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                var DBProvider = _tenantService.GetDatabaseProvider();
                if (DBProvider.ToUpper() == "MMSQL")
                {
                    optionsBuilder.UseSqlServer(_tenantService.GetConnectionString());
                }
            }
        }
    }
}
