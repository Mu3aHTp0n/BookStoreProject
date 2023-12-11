using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public interface IBaseRepository<TEntity>
    {
        TEntity GetById(long id);
        List<TEntity> GetList();

    }
}
