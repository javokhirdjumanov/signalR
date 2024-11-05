using Microsoft.EntityFrameworkCore;

namespace Core.EF
{
    public abstract class DefaultConfiguredDbContext : DbContext
    {
        protected DefaultConfiguredDbContext()
        {
        }

        protected DefaultConfiguredDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
