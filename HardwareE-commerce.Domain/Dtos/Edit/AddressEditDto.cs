namespace HardwareE_commerce.Domain;

public record AddressEditDto : EditDtoBase
{
    /// <summary>
    /// کاربر
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "کاربر مشخص نشده است")]
    public int UserId { get; set; }
    /// <summary>
    /// کشور
    /// </summary>
    [Required(ErrorMessage = "کشور مشخص نشده است")]
    public string Country { get; set; }
    /// <summary>
    /// استان
    /// </summary>
    [Required(ErrorMessage = "استان مشخص نشده است")]
    public string Province { get; set; }
    /// <summary>
    /// شهر
    /// </summary>
    [Required(ErrorMessage = "شهر مشخص نشده است")]
    public string City { get; set; }
    /// <summary>
    /// خیابان
    /// </summary>
    [Required(ErrorMessage = "خیابان مشخص نشده است")]
    public string street { get; set; }
    /// <summary>
    /// کوچه
    /// </summary>
    public string Alley { get; set; }
    /// <summary>
    /// پلاک
    /// </summary>
    [Required(ErrorMessage = "شماره پلاک مشخص نشده است")]
    public string Plak { get; set; }
    /// <summary>
    /// کد پستی
    /// </summary>
    [Required(ErrorMessage = "کدپستی مشخص نشده است")]
    public string PostalCode { get; set; }
    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string Tel { get; set; }
    /// <summary>
    /// اطلاعات تکمیلی
    /// </summary>
    public string MetaData { get; set; }
}

