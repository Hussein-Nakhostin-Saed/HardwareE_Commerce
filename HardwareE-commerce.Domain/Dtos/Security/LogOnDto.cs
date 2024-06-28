namespace HardwareE_commerce.Domain;

public class LogOnDto
{
    [Required(ErrorMessage = "کد ملی مشخص نشده است")]
    [Length(10, 10 , ErrorMessage = "کد ملی صحیح نمی باشد")]
    public string NationalNo { get; set; }

    [Required(ErrorMessage = "شماره موبایل مشخص نشده است")]
    [Length(11, 11, ErrorMessage = "شماره موبایل صحیح نمی باشد")]
    public string MobileNo { get; set; }

    [Required(ErrorMessage = "رمز عبور مشخص نشده است")]
    [RegularExpression("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$", ErrorMessage = "رمز عبور امن نیست")]
    public string Password { get; set; }

    [Required(ErrorMessage = "تایید رمز عبور مشخص نشده است")]
    [Compare("Password", ErrorMessage = "رمز عبور بت تایید رمز عبور یکسان نیست")]
    public string ConfirmPassword { get; set; }

    public LogOnDto()
    {
        
    }
}
