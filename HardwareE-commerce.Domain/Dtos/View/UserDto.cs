namespace HardwareE_commerce.Domain;

public record UserDto(string firstName,
                      string lastName,
                      string nationalNo,
                      string mobileNo,
                      string email) : DtoBase;