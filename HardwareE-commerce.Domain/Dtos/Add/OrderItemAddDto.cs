namespace HardwareE_commerce.Domain;

public record OrderItemAddDto : AddDtoBase
{
    [Range(1, int.MaxValue, ErrorMessage = "محصول مشخص نشده است")]
    public int ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "تعداد مشخص نشده است")]
    public int Quantity { get; set; }
    [Range(1, long.MaxValue, ErrorMessage = "مبلغ کل مشخص نشده است")]
    public decimal TotalAmount { get; set; }
}
