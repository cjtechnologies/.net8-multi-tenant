namespace MultiTenant.Data
{
    public interface ITenantProvider
    {
        string GetTenant();
    }

    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetTenant()
        {
            var tenant = _httpContextAccessor.HttpContext?.Request.Headers["X-Tenant"].FirstOrDefault();
            return tenant ?? "DefaultTenant";
        }
    }
}
