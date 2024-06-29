using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardwareE_commerce.Infrastructure;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasOne(x => x.Product).WithMany();
    }
}
