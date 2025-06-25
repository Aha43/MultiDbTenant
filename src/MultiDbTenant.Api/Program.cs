using MultiDbTenant.BusinessLayer;
using MultiDbTenant.Api.Midlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMultiDbTenantBusinessLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<TenantResolutionMiddleware>();

app.MapControllers();

app.Run();
