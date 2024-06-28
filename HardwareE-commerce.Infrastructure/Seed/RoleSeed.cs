namespace HardwareE_commerce.Infrastructure;

public static class RoleSeed
{
    public static IEnumerable<Role> Seed(ModelBuilder modelBuilder)
    {
        var id = 1;
        var roles = new List<Role>()
        {
            new Role(id++, "ادمین", RoleSignature.Admin)
        };

        modelBuilder.Entity<Role>().HasData(roles);

        return roles;
    }
}
