using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserAPI.CORE.Entities;

namespace UserAPI.Infrastructure.Data
{
    public class WebAppContext : IdentityDbContext<User>
    {
        public WebAppContext(DbContextOptions<WebAppContext> options)
           : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFeatureMapping> ProductFeatureMappings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Brand> Brands { get; set; }


    }
}
