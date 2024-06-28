namespace HardwareE_commerce.Domain;

public record LoginDto
{
    [Required(ErrorMessage = "کد ملی وارد نشده است")]
    [Length(10, 10, ErrorMessage = "تعداد کاراکتر های کد ملی صحیح نمی باشد")]
    public string NationalNo { get; set; }

    [Required(ErrorMessage = "رمز عبور مشخص نشده است")]
    public string Password { get; set; }
}
