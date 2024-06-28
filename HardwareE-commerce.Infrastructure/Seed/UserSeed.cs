namespace HardwareE_commerce.Infrastructure;

public static class UserSeed
{
    public static void Seed(ModelBuilder modelBuilder, IEnumerable<Role> roles)
    {
        var id = 1;
        var adminRole = roles.Single(x => x.Name.Equals("ادمین"));
        var users = new List<User>()
        {
            new User(id++, "ادمین", "ادمین", "1450000000", "09376700858", "hussein.nakhostin2000@gmail.com", "Hussein@124IranEnemiesWillDieSoon".Encrypt(), adminRole.Id)
        };

        modelBuilder.Entity<User>().HasData(users);
    }
}
