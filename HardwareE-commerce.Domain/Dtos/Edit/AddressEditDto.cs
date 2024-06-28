namespace HardwareE_commerce.Domain;

public record AddressEditDto(int userId,
                             string country,
                             string province,
                             string city,
                             string street,
                             string alley,
                             string plak,
                             string postalCode,
                             string tel,
                             string metaData) : EditDtoBase
{
    /// <summary>
    /// کاربر
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "کاربر مشخص نشده است")]
    public int UserId { get; set; } = userId;
    public User User { get; set; }
    /// <summary>
    /// کشور
    /// </summary>
    [Required(ErrorMessage = "کشور مشخص نشده است")]
    public string Country { get; set; } = country;
    /// <summary>
    /// استان
    /// </summary>
    [Required(ErrorMessage = "استان مشخص نشده است")]
    public string Province { get; set; } = province;
    /// <summary>
    /// شهر
    /// </summary>
    [Required(ErrorMessage = "شهر مشخص نشده است")]
    public string City { get; set; } = city;
    /// <summary>
    /// خیابان
    /// </summary>
    [Required(ErrorMessage = "خیابان مشخص نشده است")]
    public string street { get; set; } = street;
    /// <summary>
    /// کوچه
    /// </summary>
    public string Alley { get; set; } = alley;
    /// <summary>
    /// پلاک
    /// </summary>
    [Required(ErrorMessage = "شماره پلاک مشخص نشده است")]
    public string Plak { get; set; } = plak;
    /// <summary>
    /// کد پستی
    /// </summary>
    [Required(ErrorMessage = "کدپستی مشخص نشده است")]
    public string PostalCode { get; set; } = postalCode;
    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string Tel { get; set; } = tel;
    /// <summary>
    /// اطلاعات تکمیلی
    /// </summary>
    public string MetaData { get; set; } = metaData;
}

