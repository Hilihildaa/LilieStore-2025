using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;


public class StoreContextSeed(StoreContext context)
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.Products.Any())
        {
            var Products = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(Products);

            if (products == null) return;

            context.Products.AddRange(products);

            await context.SaveChangesAsync();
        
        }
    }
}