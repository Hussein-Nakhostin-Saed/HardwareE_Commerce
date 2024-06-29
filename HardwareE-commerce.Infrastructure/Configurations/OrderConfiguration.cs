using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardwareE_commerce.Infrastructure;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(x => x.Items).WithOne();
        builder.HasOne(x => x.User).WithMany();
        builder.HasOne(x => x.Payment).WithOne(x => x.Order).HasForeignKey<Order>(x => x.PaymentId).OnDelete(DeleteBehavior.SetNull);
    }
}
