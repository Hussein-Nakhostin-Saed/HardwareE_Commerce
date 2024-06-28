namespace HardwareE_commerce.Domain;

public class User : MutableEntity, IEquatable<User>
{
    /// <summary>
    /// نام
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// کد ملی
    /// </summary>
    public string NationalNo { get; set; }
    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string MobileNo { get; set; }
    /// <summary>
    /// ایمیل
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// رمز عبور
    /// </summary>
    public string Password { get; set; }

    public DateTime LastEntryDateTime { get; set; }
    public Role? Role { get; set; }
    public int? RoleId { get; set; }

    public User(int id,
                 string firstName,
                  string lastName,
                  string nationalNo,
                  string mobileNo,
                  string email,
                  string password,
                  int? roleId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        NationalNo = nationalNo;
        MobileNo = mobileNo;
        Email = email;
        Password = password;
        RoleId = roleId;
    }
    public User()
    {
        
    }
    public bool Equals(User? other)
    {
        if (other is null)
            return true;

        return (other!.NationalNo == NationalNo ||
                other.MobileNo == MobileNo || 
                other.Email == Email);
    }
}
