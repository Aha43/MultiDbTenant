using MultiDbTenant.BusinessLayer.Abstraction;
using MultiDbTenant.BusinessLayer.Model;

namespace MultiDbTenant.BusinessLayer.Service;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<Product?> GetProductByIdAsync(int id) => await productRepository.GetProductByIdAsync(id);
    public async Task<IEnumerable<Product>> GetAllProductsAsync() => await productRepository.GetAllProductsAsync();
    public async Task AddProductAsync(Product product) => await productRepository.AddProductAsync(product);
    public async Task UpdateProductAsync(Product product) => await productRepository.UpdateProductAsync(product);
    public async Task DeleteProductAsync(int id) => await productRepository.DeleteProductAsync(id);
}
