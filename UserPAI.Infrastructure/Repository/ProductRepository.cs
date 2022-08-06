using UserAPI.CORE.Entities;
using UserAPI.CORE.Repositories;
using UserAPI.Infrastructure.Data;
using UserAPI.Infrastructure.Repository.Base;

namespace UserAPI.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRespository
    {
        private readonly WebAppContext _dbContext;
        public ProductRepository(WebAppContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
