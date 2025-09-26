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
    options.OperationFilter<TenantHeaderOperationFilter>();
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
