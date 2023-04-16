using Microsoft.EntityFrameworkCore;
using Multitenant.Net6.Domain.Entity;
using Multitenant.Net6.Domain.Tenant.Services;

namespace Multitenant.Net6.Domain.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public string? TenantId { get; set; }

        private readonly ITenantService _tenantService;

        public AppDbContext(DbContextOptions options, 
                            ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;

            TenantId = _tenantService.GetTenantInfo()?.TenantId;
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasQueryFilter(a => a.TenantId == TenantId);
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
