using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.CORE.Entities;

namespace UserAPI.Infrastructure.Data.Seeds
{
    public  class DefaultProduct
    {
        public static async Task SeedProductAsync(WebAppContext webAppContext)
        {


            webAppContext.Database.Migrate();
            if (!webAppContext.Products.Any())
            {
                webAppContext.Products.AddRange(GetPreconfiguredOrders());
                webAppContext.ProductFeatureMappings.AddRange(GetPreconfiguredProductFeatures());
                await webAppContext.SaveChangesAsync();
            }

        }

        private static IEnumerable<Product> GetPreconfiguredOrders()
        {
            return new List<Product>()
            {
                new Product
                {
                  
                   BrandId = 1,
                   Name ="Test Product 1",
                   Price = 10
                }, 
                new Product
                {
                 
                   BrandId = 1,
                   Name ="Test Product 2",
                   Price = 100 

                },
                new Product
                {

                
                   BrandId = 2,
                   Name ="Test Product 3",
                    Price = 150
                   
                }

            };
        }
        private static IEnumerable<ProductFeatureMapping> GetPreconfiguredProductFeatures()
        {
            return new List<ProductFeatureMapping>()
            {
                new ProductFeatureMapping
                {
                
                   DiscountAmount = 5,
                   ProductFeatureId = 1,
                   FeatureValue = "Mavi",
                   ProductId = 1
                  
                },
                new ProductFeatureMapping
                {
                
                   DiscountAmount = 2,
                   ProductFeatureId = 1,
                   FeatureValue = "Sarı",
                   ProductId = 1

                },
                new ProductFeatureMapping
                {

               
                   DiscountAmount = 2,
                   ProductFeatureId = 2,
                   FeatureValue = "XL",
                   ProductId = 2

                },
                
                new ProductFeatureMapping
                {

                  
                   DiscountAmount = 5,
                   ProductFeatureId = 2,
                   FeatureValue = "36",
                   ProductId = 3

                }

            };
        }
    }
}
