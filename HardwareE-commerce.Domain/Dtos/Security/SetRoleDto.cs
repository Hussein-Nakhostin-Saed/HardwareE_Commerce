namespace HardwareE_commerce.Domain;

public class SetRoleDto
{
    [Range(1, int.MaxValue, ErrorMessage = "کاربر مشخص نشده است")]
    public int UserId { get; set; }

    public int? RoleId { get; set; }
}
