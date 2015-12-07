using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public interface IAsyncRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query();

        Task<List<TEntity>> GetAllAsync();

        Task<IList<TEntity>> GetAllAsync<T>(Expression<Func<TEntity, T>> sortBy, bool ascending, int skip, int take);

        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> GetUniqueAsync(Expression<Func<TEntity, bool>> whereClause);

        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task DeleteAsync(object id);

        void DeleteMany(Expression<Func<TEntity, bool>> whereClause);
    }
}
