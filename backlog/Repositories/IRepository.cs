using backlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.Repositories
{
    public interface IRepository<T>
      where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Add(T entity);
        Task<T> AsNoTracking(long id);
        Task<T> Update(T entity);
        Task<T> Delete(long id);

    }
}
