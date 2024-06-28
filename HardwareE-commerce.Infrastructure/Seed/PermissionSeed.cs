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

            new Permission(id++, "دسته بندی", PermissionSignatures.CategoryView),
            new Permission(id++, "ویرایش دسته بندی", PermissionSignatures.CanEditCategory),
            new Permission(id++, "محصول", PermissionSignatures.ProductView),
            new Permission(id++, "ویرایش محصول", PermissionSignatures.CanEditProduct),
            new Permission(id++, "فاکتور", PermissionSignatures.PaymentView),
            new Permission(id++, "ویرایش فاکتور", PermissionSignatures.CanEditPayment),
            new Permission(id++, "سبد خرید", PermissionSignatures.CardView),
            new Permission(id++, "ویرایش سبد خرید", PermissionSignatures.CanEditCard),
        };

        modelBuilder.Entity<Permission>().HasData(permissions);

        return permissions;
    }
}
