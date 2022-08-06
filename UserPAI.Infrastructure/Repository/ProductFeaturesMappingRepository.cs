using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.CORE.Entities;
using UserAPI.CORE.Repositories;
using UserAPI.Infrastructure.Data;
using UserAPI.Infrastructure.Repository.Base;

namespace UserAPI.Infrastructure.Repository
{
    public class ProductFeaturesMappingRepository  : Repository<ProductFeatureMapping>, IProductFeatureMappingRepository 
    {
        private readonly WebAppContext _dbContext;

        public ProductFeaturesMappingRepository(WebAppContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
