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

        CreateMap<CardItem, CardItemDto>();
        CreateMap<Card, CardDto>();
        CreateMap<CardItemAddDto, CardItem>();
        CreateMap<CardItemEditDto, CardItem>()
            .ForMember(x => x.Id, opt => opt.Ignore());

        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>();
    }
}
