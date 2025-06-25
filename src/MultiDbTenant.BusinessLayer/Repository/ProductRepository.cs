using Microsoft.EntityFrameworkCore;
using MultiDbTenant.BusinessLayer.Abstraction;
using MultiDbTenant.BusinessLayer.Data;
using MultiDbTenant.BusinessLayer.Model;

namespace MultiDbTenant.BusinessLayer.Repository;

public class ProductRepository(TenantDbContext context) : IProductRepository
{
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task AddProductAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product != null)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
    
}
