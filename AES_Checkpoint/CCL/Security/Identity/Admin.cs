namespace CCL.Security.Identity;

public class Admin : User
{
    public Admin(int userId, string userName, int reasonId) : base(userId, userName, reasonId, nameof(Admin))
    {
        
    }
}