namespace HardwareE_commerce.Domain;

public record ProductAddDto : AddDtoBase
{
    [Required(ErrorMessage = "نام محصول مشخص نشده است")]
    public string Name { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "موجودی مشخص نشده است")]
    public int Quantity { get; set; }
    [Range(1, long.MaxValue, ErrorMessage = "قیمت مشخص نشده است")]
    public decimal Price { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "دسته بندی انتخاب نشده است")]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "بارکد محصول مشخص نشده است")]
    public string BarCode { get; set; }
}
