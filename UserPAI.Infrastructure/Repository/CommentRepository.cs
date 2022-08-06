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
    public class CommentRepository : Repository<Comment>, ICommentsRepository
    {

        private readonly WebAppContext _dbContext;

        public CommentRepository(WebAppContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
