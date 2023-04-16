using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Multitenant.Net6.Domain.Tenant.Services;

namespace Multitenant.Net6.Domain.Tenant.Implementation
{
    public class TenantService : ITenantService
    {
        private HttpContext _httpContext;

        private TenantInfo _currentTenantInfo;
        
        private readonly TenantSettings _tenantSettings;

        public TenantService(IOptions<TenantSettings> tenantSettings,
                            IHttpContextAccessor contextAccessor)
        {
            _tenantSettings = tenantSettings.Value;
 
            _httpContext = contextAccessor.HttpContext;

            if (_httpContext != null)
            {
                ProvideTenant();
            }
        }
        public void ProvideTenant()
        {
            if (_httpContext.Request.Headers.TryGetValue("TenantId", out var tenantId))
            {
                _currentTenantInfo = _tenantSettings.Tenants.Where(a => a.TenantId == tenantId).FirstOrDefault()!;

                if (_currentTenantInfo is null) throw new ArgumentNullException("Unable to find TenantId!");

                _currentTenantInfo.ConnectionString = _currentTenantInfo.ConnectionString;
            }
            else
            {
                _currentTenantInfo = new TenantInfo();

                _currentTenantInfo.ConnectionString = _tenantSettings.DefaultDb.ConnectionString;
            }
        }

        public TenantInfo GetTenantInfo() => _currentTenantInfo;
     
        public string GetConnectionString() => _currentTenantInfo?.ConnectionString!;
    
        public string GetDatabaseProvider() => _tenantSettings.DefaultDb?.DBProvider!;
    }
}
