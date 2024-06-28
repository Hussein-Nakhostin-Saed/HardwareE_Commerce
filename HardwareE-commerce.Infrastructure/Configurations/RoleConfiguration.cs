using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HardwareE_commerce.Infrastructure;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasMany(x => x.Permissions).WithMany(x => x.Roles);
        builder.Property(c => c.Code).HasMaxLength(10);
        builder.Property(x => x.Name).HasMaxLength(50);
    }
}
