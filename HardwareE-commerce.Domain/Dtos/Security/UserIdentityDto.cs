namespace HardwareE_commerce.Domain;

public record class UserIdentityDto(int UserId,
                                string Username,
                                IEnumerable<string> permissions);
