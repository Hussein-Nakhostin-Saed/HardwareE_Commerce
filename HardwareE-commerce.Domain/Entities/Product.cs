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

    public Product(int id, string name, int quantity, decimal price, string barcode, int categoryId)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
        BarCode = barcode;
        CategoryId = categoryId;
    }

    public bool Equals(Product? other)
    {
        if(other is null)
            return true;

        return (other.Name.Equals(Name) || other.BarCode == BarCode);
    }
}
