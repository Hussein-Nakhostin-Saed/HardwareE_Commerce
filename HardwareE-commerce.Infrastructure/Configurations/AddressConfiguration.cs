using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardwareE_commerce.Infrastructure;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasOne(x => x.User).WithMany();

        builder.Property(x => x.Country).HasMaxLength(150);
        builder.Property(x => x.Province).HasMaxLength(150);
        builder.Property(x => x.City).HasMaxLength(150);
        builder.Property(x => x.street).HasMaxLength(150);
        builder.Property(x => x.Alley).HasMaxLength(150);
        builder.Property(x => x.Plak).HasMaxLength(10);
        builder.Property(x => x.PostalCode).HasMaxLength(20);
        builder.Property(x => x.Tel).HasMaxLength(20);
        builder.Property(x => x.MetaData).HasMaxLength(500);
    }
}
