using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.CORE.Repositories;
using UserAPI.CORE.Repositories.Base;
using UserAPI.Infrastructure.Data;
using UserAPI.Infrastructure.Repository;
using UserAPI.Infrastructure.Repository.Base;

namespace UserAPI.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
        


            #region ProjectDependencies
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IBrandRepository), typeof(BrandRepository));
            services.AddScoped(typeof(ICommentsRepository), typeof(CommentRepository));
            services.AddScoped(typeof(IProductFeatureMappingRepository), typeof(ProductFeaturesMappingRepository));
            services.AddScoped(typeof(IProductFeatureRepository), typeof(ProductFeaturesRepository));
            services.AddScoped(typeof(IProductRespository), typeof(ProductRepository));
            #endregion


            return services;
        }
    }
}
