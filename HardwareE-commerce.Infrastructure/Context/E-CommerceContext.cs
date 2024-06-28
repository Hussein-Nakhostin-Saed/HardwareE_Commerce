namespace HardwareE_commerce.Infrastructure;

public class E_CommerceContext : DbContext
{
    public E_CommerceContext(DbContextOptions<E_CommerceContext> options) : base(options)
    {
    }

    public E_CommerceContext()
    {
        
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    //public DbSet<Order> Orders { get; set; }
    //public DbSet<Payment> Payments { get; set; }
    //public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    //public DbSet<Card> Cards { get; set; }
    //public DbSet<CardItem> CardItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-0EP26IN\\HUSSEIN;Initial Catalog=HardwareE_commerce;User Id=sa;Password=Hussein@124;MultipleActiveResultSets=True;TrustServerCertificate=True;Trusted_Connection=True;");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(E_CommerceContext).Assembly);
        base.OnModelCreating(modelBuilder);
        SeedBase.Seed(modelBuilder);
    }
}
