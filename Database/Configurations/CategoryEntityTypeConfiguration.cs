using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFM.Database.Entities;

namespace PFM.Database.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public CategoryEntityTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("categories");
            //  primary key
            builder.HasKey(x => x.Code);
            //  definition of columns
            builder.Property(x => x.ParentCode);
            builder.Property(x=>x.CatName).HasMaxLength(64);
        }
    }
}
