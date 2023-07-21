using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFM.Database.Entities;

namespace PFM.Database.Configurations
{
    public class TransactonSplitEntityTypeConfiguration : IEntityTypeConfiguration<TransactionSplitEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionSplitEntity> builder)
        {
            builder.ToTable("transaction-splits");
            // primarni kljuc
            builder.HasKey(x => x.Id);
            // definisanje kolona
            builder.Property(x => x.TransactionId);
            builder.Property(x => x.CatCode);
            builder.Property(x => x.Amount);
        }
    }
}
