using Microsoft.Extensions.DependencyInjection;
using MultiDbTenant.BusinessLayer;

var tenant = args.Length > 0 ? args[0] : throw new ArgumentException("Tenant ID is required as the first argument.");

var services = new ServiceCollection();
services.AddMultiDbTenantBusinessLayer();