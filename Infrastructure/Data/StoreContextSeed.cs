using System.Text.Json;
using API.Data;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            Console.WriteLine("Start seeding");
            Console.WriteLine("Any brands" + context.ProductBrands.Any());

            if(!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData); 
                context.ProductBrands.AddRange(brands);
                Console.WriteLine("Seeding ProductBrands...");
            }

             if(!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData); 
                context.ProductTypes.AddRange(types);
                Console.WriteLine("Seeding ProductTypes...");
            }

             if(!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData); 
                context.Products.AddRange(products);
                Console.WriteLine("Seeding Products...");
            }

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}