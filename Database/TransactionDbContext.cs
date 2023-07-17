using Microsoft.EntityFrameworkCore;
using PFM.Database.Configurations;
using PFM.Database.Entities;

namespace PFM.Database
{
    public class TransactionDbContext : DbContext
    {
        public DbSet<TransactionEntity> Transactions { get; set; }

        public TransactionDbContext(DbContextOptions options) : base(options)
        {
        }

        public TransactionDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            modelBuilder.ApplyConfiguration(
                new TransactionEntityTypeConfiguration()
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
