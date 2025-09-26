using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MultiTenant.Filters
{
    public class TenantHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Tenant",
                In = ParameterLocation.Header,
                Required = true, // set false if optional
                Schema = new OpenApiSchema
                {
                    Type = "string"
                },
                Description = "Tenant identifier (e.g. Org1, Org2)"
            });
        }
    }
}
