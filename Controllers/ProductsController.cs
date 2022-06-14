using Microsoft.AspNetCore.Mvc;
using AspNetWebApp.Models;

namespace AspNetWebApp.Controllers;

[ApiController]
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
    public async Task<IActionResult> GetProduct(long id)
    {
        Product? p = await context.Products.FindAsync(id);
        if (p == null)
        {
            return NotFound();
        }
        return Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> 
        SaveProducts(ProductBindingTarget target)
    {
        Product p = target.ToProduct();
        await context.Products.AddAsync(p);
        await context.SaveChangesAsync();
        return Ok(p);
    }

    [HttpPut]
    public async Task UpdateProduct(Product product)
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