using Microsoft.EntityFrameworkCore;
using MultiDbTenant.BusinessLayer.Abstraction;
using MultiDbTenant.BusinessLayer.Data;
using MultiDbTenant.BusinessLayer.Model;

namespace MultiDbTenant.BusinessLayer.Repository;

public class ProductRepository(TenantDbContext context) : IProductRepository
{
    private readonly TenantDbContext _context = context;

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
    
}
