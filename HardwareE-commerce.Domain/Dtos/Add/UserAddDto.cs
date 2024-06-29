namespace HardwareE_commerce.Domain;

public record UserAddDto : AddDtoBase
{
    /// <summary>
    /// نام
    /// </summary>
    [Required(ErrorMessage = "نام مشخص نشده است")]
    public string FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [Required(ErrorMessage = "نام خانوادگی مشخص نشده است")]
    public string LastName { get; set; }
    /// <summary>
    /// کد ملی
    /// </summary>
    [Required(ErrorMessage = "کد ملی مشخص نشده است")]
    [Length(10, 10, ErrorMessage = "تعداد کاراکتر های کد ملی صحیح نمی باشد.")]
    public string NationalNo { get; set; }
    /// <summary>
    /// شماره تلفن
    /// </summary>
    [Required(ErrorMessage = "شماره موبایل مشخص نشده است")]
    public string MobileNo { get; set; }
    /// <summary>
    /// ایمیل
    /// </summary>
    [Required(ErrorMessage = "ایمیل مشخص نشده است")]
    public string Email { get; set; }
    /// <summary>
    /// رمز عبور
    /// </summary>
    [Required]
    [RegularExpression("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$", ErrorMessage = "رمز عبور امن نیست")]
    public string Password { get; set; }
}