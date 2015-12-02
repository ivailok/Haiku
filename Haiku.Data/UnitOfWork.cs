using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public class UnitOfWork : IDisposable
    {
        private HaikuContext context;
        private IAsyncRepository<User> usersRepository;
        private IAsyncRepository<HaikuEntity> haikusRepository;
        private bool disposedValue = false;

        public UnitOfWork()
        {
            this.context = new HaikuContext();
        }

        public IAsyncRepository<User> UsersRepository
        {
            get
            {
                if (this.usersRepository == null)
                {
                    this.usersRepository = new DbAsyncRepository<User>(this.context);
                }
                return this.usersRepository;
            }
        }

        public IAsyncRepository<HaikuEntity> HaikusRepository
        {
            get
            {
                if (this.haikusRepository == null)
                {
                    this.haikusRepository = new DbAsyncRepository<HaikuEntity>(this.context);
                }
                return this.haikusRepository;
            }
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
