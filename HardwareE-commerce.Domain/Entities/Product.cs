namespace HardwareE_commerce.Domain;

public class Product : MutableEntity
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Product()
    {
        
    }
}
