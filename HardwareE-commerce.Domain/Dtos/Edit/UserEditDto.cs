namespace HardwareE_commerce.Domain;

public record UserEditDto(string firstName,
                          string lastName,
                          string nationalNo,
                          string mobileNo,
                          string email,
                          string password) : EditDtoBase
{
    /// <summary>
    /// نام
    /// </summary>
    [Required(ErrorMessage = "نام مشخص نشده است")]
    public string FirstName { get; set; } = firstName;
    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [Required(ErrorMessage = "نام خانوادگی مشخص نشده است")]
    public string LastName { get; set; } = lastName;
    /// <summary>
    /// کد ملی
    /// </summary>
    [Required(ErrorMessage = "کد ملی مشخص نشده است")]
    [Length(10, 10, ErrorMessage = "تعداد کاراکتر های کد ملی صحیح نمی باشد.")]
    public string NationalNo { get; set; } = nationalNo;
    /// <summary>
    /// شماره تلفن
    /// </summary>
    [Required(ErrorMessage = "شماره موبایل مشخص نشده است")]
    public string MobileNo { get; set; } = mobileNo;
    /// <summary>
    /// ایمیل
    /// </summary>
    [Required(ErrorMessage = "ایمیل مشخص نشده است")]
    [RegularExpression("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])", ErrorMessage = "آدرس ایمیل خود را در فرمت صحیح وارد نمایید")]
    public string Email { get; set; } = email;
    /// <summary>
    /// رمز عبور
    /// </summary>
    [Required]
    [RegularExpression("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$", ErrorMessage = "رمز عبور امن نیست")]
    public string Password { get; set; } = password;
}
