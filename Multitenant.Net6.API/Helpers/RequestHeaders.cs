namespace Multitenant.Net6.API.Helpers
{
    public static class RequestHeaders
    {
        public static string GetTenantIdFromHeader(this HttpContext httpContext)
        {
            var tenantId = httpContext.Request.Headers["TenantId"].FirstOrDefault();

            if (string.IsNullOrEmpty(tenantId)) throw new Exception("Unable to find TenantId!");

            return tenantId;
        }
    }
}
