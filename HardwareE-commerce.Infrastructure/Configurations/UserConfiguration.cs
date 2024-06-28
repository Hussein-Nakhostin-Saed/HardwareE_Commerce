using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardwareE_commerce.Infrastructure;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(50);
        builder.Property(x => x.LastName).HasMaxLength(50);
        builder.Property(x => x.NationalNo).HasMaxLength(20);
        builder.Property(x => x.MobileNo).HasMaxLength(20);
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.Property(x => x.Password).HasMaxLength(1000);
    }
}
