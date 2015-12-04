using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext context;
        private IAsyncRepository<User> usersRepository;
        private IAsyncRepository<HaikuEntity> haikusRepository;
        private bool disposedValue = false;

        public UnitOfWork(
            IDbContext context,
            IAsyncRepository<User> usersRepository, 
            IAsyncRepository<HaikuEntity> haikusRepository)
        {
            this.context = context;
            this.usersRepository = usersRepository;
            this.haikusRepository = haikusRepository;
        }

        public IAsyncRepository<User> UsersRepository
        {
            get { return this.usersRepository; }
        }

        public IAsyncRepository<HaikuEntity> HaikusRepository
        {
            get { return this.haikusRepository; }
        }

        public Task SaveAsync()
        {
            return this.context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (this.context != null)
                    {
                        this.context.Dispose();
                        this.context = null;
                    }
                }

                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
