using Microsoft.EntityFrameworkCore;
using Persons.Domain.Entities;

namespace Persons.Infrastructure.Contexts
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options)
        {

        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Person>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Scope>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
