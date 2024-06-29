namespace HardwareE_commerce.Infrastructure;

public static class ProductSeed
{
    public static void Seed(ModelBuilder modelBuilder, int categoryId)
    {
        var product = new Product(1, "مادر بدر", 20, 50000000, "54654635", categoryId);

        modelBuilder.Entity<Product>().HasData(product);
    }
}
