using Haiku.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    public class HaikuContext : DbContext
    {
        public HaikuContext()
            : base("name=HaikuDBConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<HaikuEntity> Haikus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
