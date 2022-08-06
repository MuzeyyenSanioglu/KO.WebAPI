using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.CORE.Entities;
using UserAPI.CORE.Repositories.Base;

namespace UserAPI.CORE.Repositories
{
    public interface ICommentsRepository: IRepository<Comment>
    {
    }
}
