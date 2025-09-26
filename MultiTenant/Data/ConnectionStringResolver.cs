namespace MultiTenant.Data
{
    public interface IConnectionStringResolver
    {
        string Resolve(string tenant);
    }

    public class ConnectionStringResolver : IConnectionStringResolver
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(string tenant)
        {
            // Example: stored in appsettings.json
            return _configuration.GetConnectionString(tenant);
        }
    }
}
