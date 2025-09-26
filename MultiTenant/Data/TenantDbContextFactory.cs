using Microsoft.EntityFrameworkCore;

namespace MultiTenant.Data
{
    public class TenantDbContextFactory
    {
        private readonly IConnectionStringResolver _resolver;
        private readonly ITenantProvider _tenantProvider;

        public TenantDbContextFactory(IConnectionStringResolver resolver, ITenantProvider tenantProvider)
        {
            _resolver = resolver;
            _tenantProvider = tenantProvider;
        }

        public AppDbContext CreateDbContext()
        {
            var tenant = _tenantProvider.GetTenant();
            var connStr = _resolver.Resolve(tenant);

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connStr);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
