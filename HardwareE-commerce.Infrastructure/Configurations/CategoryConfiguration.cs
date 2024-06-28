using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardwareE_commerce.Infrastructure;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasOne(x => x.Parent).WithMany();
        builder.Property(x => x.Name).HasMaxLength(50);
    }
}
