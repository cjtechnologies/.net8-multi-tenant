using Microsoft.OpenApi.Models;
using MultiTenant.Data;
using MultiTenant.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(new TenantSettings());
builder.Services.AddScoped<ITenantProvider, TenantProvider>();
builder.Services.AddScoped<IConnectionStringResolver, ConnectionStringResolver>();
builder.Services.AddScoped<TenantDbContextFactory>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // JWT auth (if you already have it)
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        Description = "Enter JWT Bearer token"
    });

    // Tenant header auth
    options.AddSecurityDefinition("Tenant", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "X-Tenant",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Tenant",
        Description = "Tenant name (e.g. Org1, Org2)"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        },
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Tenant"
                }
            },
            new List<string>()
        }
    });
    //options.OperationFilter<TenantHeaderOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
