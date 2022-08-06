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
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly WebAppContext _dbContext;
        public BrandRepository(WebAppContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
