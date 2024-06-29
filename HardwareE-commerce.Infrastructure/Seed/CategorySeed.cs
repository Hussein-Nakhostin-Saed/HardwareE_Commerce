using HardwareE_commerce.Domain;

namespace HardwareE_commerce.Infrastructure;

public static class CategorySeed
{
    public static Category Seed(ModelBuilder modelBuilder)
    {
        var cat = new Category(1, "برد");
        modelBuilder.Entity<Category>().HasData(cat);

        return cat;
    }
}
