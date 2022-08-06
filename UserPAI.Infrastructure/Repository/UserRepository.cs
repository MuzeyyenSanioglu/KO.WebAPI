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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly WebAppContext _dbContext;

        public UserRepository(WebAppContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
