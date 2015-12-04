using Haiku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<User> UsersRepository { get; }

        IAsyncRepository<HaikuEntity> HaikusRepository { get; }

        Task SaveAsync();
    }
}
