using Haiku.Data;
using Haiku.Data.Entities;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class HaikuContext : DbContext, IDbContext
    {
        public HaikuContext()
            : base("name=HaikuDBConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<HaikuEntity> Haikus { get; set; }

        public DbSet<HaikuRating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HaikuEntity>().Property(c => c.Text).HasColumnType("longtext");
            modelBuilder.Entity<Report>().Property(c => c.Reason).HasColumnType("longtext");
            base.OnModelCreating(modelBuilder);
        }
    }
}
