namespace HardwareE_commerce.Domain;

public record CategoryAddDto : AddDtoBase
{
    [Required(ErrorMessage = "نام دسته مشخص نشده است")]
    public string Name { get; set; }
    public int? ParentId { get; set; }
}
