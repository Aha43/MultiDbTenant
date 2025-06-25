using Microsoft.AspNetCore.Mvc;
using MultiDbTenant.BusinessLayer.Abstraction;
using MultiDbTenant.BusinessLayer.Model;

namespace MultiDbTenant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(
    ILogger<ProductController> logger,
    IProductService productService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        logger.LogInformation("Fetching product with ID: {Id}", id);

        var product = await productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        logger.LogInformation("Fetching all products");

        var products = await productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync([FromBody] Product product)
    {
        logger.LogInformation("Adding new product: {@Product}", product);

        if (product == null)
        {
            return BadRequest("Product cannot be null");
        }
        await productService.AddProductAsync(product);
        return CreatedAtAction(nameof(GetProductByIdAsync), new { id = product.Id }, product);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
    {
        logger.LogInformation("Updating product: {@Product}", product);

        if (product == null)
        {
            return BadRequest("Product cannot be null");
        }
        await productService.UpdateProductAsync(product);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        logger.LogInformation("Deleting product with ID: {Id}", id);
        
        await productService.DeleteProductAsync(id);
        return NoContent();
    }
    
}
