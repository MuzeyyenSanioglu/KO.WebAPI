using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.CORE.Entities;

namespace UserAPI.Infrastructure.Data.Seeds
{
    public static class DefaultBrand
    {
        public static async Task SeedBrandAsync(WebAppContext webAppContext )
        {
           
            
                webAppContext.Database.Migrate();
                if (!webAppContext.Brands.Any())
                {
                    webAppContext.Brands.AddRange(GetPreconfiguredOrders());
                    await webAppContext.SaveChangesAsync();
                }
            
        }

        private static IEnumerable<Brand> GetPreconfiguredOrders()
        {
            return new List<Brand>()
            {
                new Brand
                {
                    
                    BrandName = "Test1", 
                }, new Brand
                {
                   
                    BrandName = "Test2",


                }
            };
        }
    }
}
