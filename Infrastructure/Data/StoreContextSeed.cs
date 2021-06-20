using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {

        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {

            try
            {
                if (!context.ProductBrands.Any())
                {
                    var BrandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                    foreach(var brand in Brands)
                    {
                        context.ProductBrands.Add(brand);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var TypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                    foreach (var type in Types)
                    {
                        context.ProductTypes.Add(type);
                    }

                    await context.SaveChangesAsync();
                }


                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }

                    await context.SaveChangesAsync();
                }
            }

            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "An error occured during migration");
            }
        }

    }
}
