﻿using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public class DbAsyncRepository<TEntity> : IAsyncRepository<TEntity>
        where TEntity : class
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

        public Task<TEntity> GetByIdAsync(object id)
        {
            return this.entities.FindAsync(id);
        }

        public TEntity Add(TEntity entity)
        {
            return this.entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entity = await this.entities.FindAsync(id);
            this.Delete(entity);
        }
    }
}
