namespace HardwareE_commerce.Domain;

public record class ChangePasswordDto(int UserId,
                                      string Password,
                                      string newPassword,
                                      string ConfirmNewPassword);
