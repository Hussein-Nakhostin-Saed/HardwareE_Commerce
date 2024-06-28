namespace HardwareE_commerce.Domain;

public record AddressDto(int userId,
                           string country,
                           string province,
                           string city,
                           string street,
                           string alley,
                           string plak,
                           string postalCode,
                           string tel,
                           string metaData) : DtoBase;
