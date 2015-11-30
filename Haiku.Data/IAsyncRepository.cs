using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public interface IAsyncRepository
    {
        IQueryable<TEntity> Query<TEntity>()
            where TEntity : TEntity<object>;

        Task<List<TEntity>> GetAllAsync<TEntity>()
            where TEntity : TEntity<object>;

        Task<TEntity> GetByIdAsync<TEntity, TId>(TId id)
            where TEntity : TEntity<object>
            where TId : IComparable, IComparable<TId>;

        Task<TEntity> AddAsync<TEntity>(TEntity entity)
            where TEntity : TEntity<object>;

        Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : TEntity<object>;

        Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : TEntity<object>;

        Task DeleteAsync<TEntity, TId>(TId id)
            where TEntity : TEntity<object>
            where TId : IComparable, IComparable<TId>;

        Task<int> SaveChangesAsync();
    }
}
