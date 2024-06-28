namespace HardwareE_commerce.Domain;

public class CardItem
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public CardItem()
    {
        
    }
}
