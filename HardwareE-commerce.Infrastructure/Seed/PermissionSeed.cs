namespace HardwareE_commerce.Infrastructure;

public static class PermissionSeed
{
    public static IEnumerable<Permission> Seed(ModelBuilder modelBuilder)
    {
        var id = 1;
        var permissions = new List<Permission>()
        {
            new Permission(id++, "آدرس", PermissionSignatures.AddressView),
            new Permission(id++, "ویرایش آدرس", PermissionSignatures.CanEditAddress),
            new Permission(id++, "کاربران", PermissionSignatures.UserView),
            new Permission(id++, "ویرایش کاربر", PermissionSignatures.CanEditUser),
            new Permission(id++, "ارکان", PermissionSignatures.RoleView),
            new Permission(id++, "ویرایش ارکان", PermissionSignatures.CanEditRole),
        };

        modelBuilder.Entity<Permission>().HasData(permissions);

        return permissions;
    }
}
