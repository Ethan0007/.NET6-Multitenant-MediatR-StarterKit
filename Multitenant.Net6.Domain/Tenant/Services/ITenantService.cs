using Multitenant.Net6.Domain.Repository;
 
namespace Multitenant.Net6.Domain.Tenant.Services
{
    public interface ITenantService : IService
    {
        public string GetDatabaseProvider();
        public string GetConnectionString();
        public TenantInfo GetTenantInfo();
    }
}
