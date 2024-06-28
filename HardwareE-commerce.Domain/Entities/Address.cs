namespace HardwareE_commerce.Domain;

public class Address(int userId, 
                     string country, 
                     string province, 
                     string city, 
                     string street, 
                     string alley, 
                     string plak, 
                     string postalCode, 
                     string tel, 
                     string metaData) : MutableEntity
{
    /// <summary>
    /// کاربر
    /// </summary>
    public int UserId { get; set; } = userId;
    public User User { get; set; }
    /// <summary>
    /// کشور
    /// </summary>
    public string Country { get; set; } = country;
    /// <summary>
    /// استان
    /// </summary>
    public string Province { get; set; } = province;
    /// <summary>
    /// شهر
    /// </summary>
    public string City { get; set; } = city;
    /// <summary>
    /// خیابان
    /// </summary>
    public string street { get; set; } = street;
    /// <summary>
    /// کوچه
    /// </summary>
    public string Alley { get; set; } = alley;
    /// <summary>
    /// پلاک
    /// </summary>
    public string Plak { get; set; } = plak;
    /// <summary>
    /// کد پستی
    /// </summary>
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
