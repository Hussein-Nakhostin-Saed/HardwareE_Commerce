using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardwareE_commerce.Infrastructure;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasMany(x => x.CardItems).WithOne();
        builder.HasOne(x => x.User).WithMany();
    }
}
