using Products.Domain.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Products.Infrastructure.CallSeeder
{
    public static class ProductSeeder
    {
        public static void SeedFromJson(ProductDbContext context)
        {
            var products = new List<ProductEntity>();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(baseDirectory, "SeedData", "ProductSeed.json");

            if (!File.Exists(path))
                throw new FileNotFoundException($"Seed file not found at: {path}");

            //var json = File.ReadAllText(path);
            //var products = JsonSerializer.Deserialize<List<ProductEntity>>(json);


            string json = File.ReadAllText(path);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
             products = JsonSerializer.Deserialize<List<ProductEntity>>(json, options);

         if (products == null || products.Count == 0)
{
    Console.WriteLine("Deserialize failed or product list is empty.");
    return;
}
            foreach (var product in products)
            {
                if (!context.Products.Any(p => p.Id == product.Id)) // ❌ DataReader هنوز بازه
                {
                    context.Products.Add(product);
                }
                
            }
            context.SaveChangesAsync();


        }
        public static async Task SeedAsync(ProductDbContext context)
        {
            if (!context.Products.Any())
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string jsonPath = Path.Combine(baseDirectory, "SeedData", "ProductSeed.json");

                if (!File.Exists(jsonPath))
                    throw new FileNotFoundException($"Seed file not found: {jsonPath}");

                string json = File.ReadAllText(jsonPath);
                //var products = JsonSerializer.Deserialize<List<ProductEntity>>(json);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var products = JsonSerializer.Deserialize<List<ProductEntity>>(json, options);


                if (products is not null)
                {
                    foreach (var product in products)
                    {
                        //product.CreationDateTime = DateTime.UtcNow;
                        //    product.ModificationDateTime = DateTime.UtcNow;
                        context.Products.Add(product);
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }

}
