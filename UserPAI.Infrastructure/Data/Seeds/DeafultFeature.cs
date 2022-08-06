using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.CORE.Entities;

namespace UserAPI.Infrastructure.Data.Seeds
{
    public class DeafultFeature
    {
        public static  void  SeedFeaturesAsync(WebAppContext webAppContext)
        {


            webAppContext.Database.Migrate();
            if (!webAppContext.ProductFeatures.Any())
            {
                webAppContext.ProductFeatures.AddRange(GetPreconfiguredOrders());
                var result =  webAppContext.SaveChanges();
            }

        }

        private static IEnumerable<ProductFeature> GetPreconfiguredOrders()
        {
            return new List<ProductFeature>()
            {
                new ProductFeature
                { 
                    FeatureName = "colour",
                }, new ProductFeature
                {
                    FeatureName = "size",
                },
                 new ProductFeature
                {
                    FeatureName = "weight",
                }

            };
        }
    }
}
