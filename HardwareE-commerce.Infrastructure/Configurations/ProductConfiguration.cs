using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardwareE_commerce.Infrastructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(x => x.Category).WithMany();
        builder.Property(x => x.Name).HasMaxLength(150);
        builder.Property(x => x.BarCode).HasMaxLength(50);
    }
}
