using Microsoft.EntityFrameworkCore;
using PFM.Database.Configurations;
using PFM.Database.Entities;

namespace PFM.Database
{
    public class CategoryDbContext : DbContext
    {

        public DbSet<CategoryEntity> Categories { get; set; }

        public CategoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public CategoryDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            modelBuilder.ApplyConfiguration(
                new CategoryEntityTypeConfiguration()
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
