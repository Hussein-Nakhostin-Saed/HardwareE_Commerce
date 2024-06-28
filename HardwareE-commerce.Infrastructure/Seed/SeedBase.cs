namespace HardwareE_commerce.Infrastructure;

public static class SeedBase
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var roles = RoleSeed.Seed(modelBuilder);
        var permisseions = PermissionSeed.Seed(modelBuilder);
        PermissionRoleSeed.Seed(modelBuilder, roles, permisseions);
        UserSeed.Seed(modelBuilder, roles);
    }
}
