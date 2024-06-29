namespace HardwareE_commerce.Infrastructure;

public static class PermissionRoleSeed
{
    public static void Seed(ModelBuilder modelBuilder, IEnumerable<Role> roles, IEnumerable<Permission> permissions)
    {
        var id = 1;
        var adminRoleId = roles.Single(x => x.Code == RoleSignature.Admin).Id;

        var permissionRoles = new List<object>()
        {
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.UserView).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CanEditUser).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.AddressView).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CanEditAddress).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.RoleView).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CanEditRole).Id, RolesId = adminRoleId },

            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CategoryView).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CanEditCategory).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.ProductView).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CanEditProduct).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.PaymentView).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CanEditPayment).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CardView).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CanEditCard).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.UserCanEditCard).Id, RolesId = adminRoleId },
            new { Id = id++, PermissionsId = permissions.Single(x => x.Code == PermissionSignatures.CardUserView).Id, RolesId = adminRoleId },
        };

        modelBuilder.Entity("PermissionRole").HasData(permissionRoles);
    }
}
