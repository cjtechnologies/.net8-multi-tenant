namespace MultiTenant.Data
{
    public class Tenant
    {
        public required string Name { get; set; }
        public required string ConnectionString { get; set; }
    }

    public class TenantSettings
    {
        public List<Tenant> Tenants =
        [
        new() {
            Name = "Tenant",
            ConnectionString = "Server=127.0.0.1;Initial Catalog=mt;Persist Security Info=True;User ID=sa;Password=admin@123;Encrypt=True;TrustServerCertificate=true;MultipleActiveResultSets=True;"
        },
        new() {
            Name = "TenantA",
            ConnectionString = "Server=127.0.0.1;Initial Catalog=mt1;Persist Security Info=True;User ID=sa;Password=admin@123;Encrypt=True;TrustServerCertificate=true;MultipleActiveResultSets=True;"
        },
        new() {
            Name = "TenantB",
            ConnectionString = "Server=127.0.0.1;Initial Catalog=mt2;Persist Security Info=True;User ID=sa;Password=admin@123;Encrypt=True;TrustServerCertificate=true;MultipleActiveResultSets=True;"
        }
        ];
    }
}
