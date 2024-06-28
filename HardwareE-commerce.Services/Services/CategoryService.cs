namespace HardwareE_commerce.Services;

public class CategoryService : ServiceBase<CategoryAddDto, CategoryEditDto, CategoryDto, Category>
{
    public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
