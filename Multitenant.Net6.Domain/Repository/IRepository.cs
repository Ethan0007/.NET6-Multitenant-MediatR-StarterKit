using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Domain.Repository
{
    public interface IRepository<TEntity>  : IService
    {
        Task<TEntity> Get(Guid id);
        IEnumerable<TEntity> GetAll();
        Task Add(TEntity entity);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task Update(TEntity entity);
    }
}
