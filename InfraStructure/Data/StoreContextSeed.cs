using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Core.Entities;
using System.Collections.Generic;
using System;

namespace InfraStructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrands .Any())
                {
                    var brandData = File.ReadAllText("../InfraStructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);                                              
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var TypeData = File.ReadAllText("../InfraStructure/Data/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);
                    foreach (var items in Types)
                    {
                        context.ProductTypes.Add(items);
                    }
                   await  context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var ProductData = File.ReadAllText("../InfraStructure/Data/SeedData/Products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                    foreach (var items in Products)
                    {
                        context.Products.Add(items);
                    }
                    await context.SaveChangesAsync();
                }
            }   
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
         
        }
    }
}
