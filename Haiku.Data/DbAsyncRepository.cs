using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public class DbAsyncRepository : IAsyncRepository
    {
        private readonly HaikuContext context;

        public DbAsyncRepository(HaikuContext context)
        {
            this.context = context;
        }

        private DbSet<TEntity> Entities<TEntity>()
            where TEntity : TEntity<object>
        {
            return this.context.Set<TEntity>();
        }
        
        public IQueryable<TEntity> Query<TEntity>()
            where TEntity : TEntity<object>
        {
            return this.Entities<TEntity>().AsQueryable();
        }
        
        public Task<List<TEntity>> GetAllAsync<TEntity>()
            where TEntity : TEntity<object>
        {
            return this.Entities<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetByIdAsync<TEntity, TId>(TId id)
            where TEntity : TEntity<object>
            where TId : IComparable, IComparable<TId>
        {
            return this.Entities<TEntity>().FindAsync(id);
        }

        public Task<TEntity> AddAsync<TEntity>(TEntity entity) 
            where TEntity : TEntity<object>
        {
            return Task.Run(() =>
            {
                return this.Entities<TEntity>().Add(entity);
            });
        }

        public Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : TEntity<object>
        {
            return Task.Run(() =>
            {
                this.context.Entry(entity).State = EntityState.Modified;
            });
        }

        public Task DeleteAsync<TEntity>(TEntity entity) 
            where TEntity : TEntity<object>
        {
            return Task.Run(() =>
            {
                this.context.Entry(entity).State = EntityState.Deleted;
            });
        }

        public Task DeleteAsync<TEntity, TId>(TId id)
            where TEntity : TEntity<object>
            where TId: IComparable, IComparable<TId>
        {
            TEntity entity = this.GetByIdAsync<TEntity, TId>(id).Result;
            return this.DeleteAsync(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }
    }
}
