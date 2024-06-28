namespace HardwareE_commerce.Domain;

public class Product : MutableEntity, IEquatable<Product>
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string BarCode { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Product()
    {
        
    }

    public bool Equals(Product? other)
    {
        return (other.Name.Equals(Name) || other.BarCode == BarCode);
    }
}
