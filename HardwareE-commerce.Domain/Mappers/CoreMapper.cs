namespace HardwareE_commerce.Domain;

[ObjectMapper]
public class CoreMapper : Profile
{
    public CoreMapper()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductAddDto, Product>();
        CreateMap<ProductEditDto, Product>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryAddDto, Category>();
        CreateMap<CategoryEditDto, Category>();
    }
}
