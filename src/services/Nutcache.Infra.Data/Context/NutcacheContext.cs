using Microsoft.EntityFrameworkCore;
using Nutcache.Infra.Data.Context.Mappings;

namespace Nutcache.Infra.Data.Context
{
    public class NutcacheContext : DbContext
    {
        public NutcacheContext() { }

        public NutcacheContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmplopyeeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
