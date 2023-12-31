namespace CCL.Security.Identity;

public class Admin : User
{
    public Admin(int userId, string userName) : base(userId, userName, nameof(Admin))
    {
        
    }
}