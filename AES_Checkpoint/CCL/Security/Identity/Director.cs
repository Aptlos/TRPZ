namespace CCL.Security.Identity;

public class Director : User
{
    public Director(int userId, string userName) : base(userId, userName, nameof(Director))
    {
        
    }
}