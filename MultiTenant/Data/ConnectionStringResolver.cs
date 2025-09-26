namespace MultiTenant.Data
{
    public interface IConnectionStringResolver
    {
        string Resolve(string tenant);
    }

    public class ConnectionStringResolver : IConnectionStringResolver
    {
        private readonly TenantSettings _settings;

        public ConnectionStringResolver(TenantSettings settings)
        {
            _settings = settings;
        }

        public string Resolve(string tenant)
        {
            var tenantConfig = _settings.Tenants.FirstOrDefault(t => t.Name.Equals(tenant, StringComparison.OrdinalIgnoreCase));
            if (tenantConfig == null)
            {
                throw new Exception($"No connection string found for tenant '{tenant}'");
            }
            return tenantConfig.ConnectionString;
        }
    }
}
