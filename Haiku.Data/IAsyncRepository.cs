using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public interface IAsyncRepository<TEntity, TId>
        where TEntity : TEntity<TId>
        where TId: IComparable, IComparable<TId>    
    {
        IQueryable<TEntity> Query();

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TId id);

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(TId id);

        Task<int> SaveChangesAsync();
    }
}
