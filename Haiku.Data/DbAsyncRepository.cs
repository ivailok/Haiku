using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public class DbAsyncRepository<TEntity, TId> : IAsyncRepository<TEntity, TId>
        where TEntity : TEntity<TId>
        where TId : IComparable, IComparable<TId>
    {
        private HaikuContext context;
        private DbSet<TEntity> entities;

        public DbAsyncRepository(HaikuContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }
        
        public IQueryable<TEntity> Query()
        {
            return this.entities.AsQueryable();
        }
        
        public Task<List<TEntity>> GetAllAsync()
        {
            return this.entities.ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(TId id)
        {
            return this.entities.FindAsync(id);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            return Task.Run(() =>
            {
                return this.entities.Add(entity);
            });
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Task.Run(() =>
            {
                this.context.Entry(entity).State = EntityState.Modified;
            });
        }

        public Task DeleteAsync(TEntity entity)
        {
            return Task.Run(() =>
            {
                this.context.Entry(entity).State = EntityState.Deleted;
            });
        }

        public Task DeleteAsync(TId id)
        {
            TEntity entity = this.GetByIdAsync(id).Result;
            return this.DeleteAsync(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }
    }
}
