using Microsoft.AspNetCore.Mvc;
using AspNetWebApp.Models;

namespace AspNetWebApp.Controllers;

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private DataContext context;

    public ProductsController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IAsyncEnumerable<Product> GetProducts()
    {
        return context.Products.AsAsyncEnumerable();
    }

    [HttpGet("{id}")]
    public async Task<Product?> GetProduct(long id)
    {
        return await context.Products.FindAsync(id);
    }

    [HttpPost]
    public async Task SaveProducts([FromBody] ProductBindingTarget target)
    {
        await context.Products.AddAsync(target.ToProduct());
        await context.SaveChangesAsync();
    }

    [HttpPut]
    public async Task UpdateProduct([FromBody] Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    [HttpDelete("{id}")]
    public async Task DeleteProduct(long id)
    {
        context.Products.Remove(new Product() { ProductId = id});
        await context.SaveChangesAsync();
    }
}