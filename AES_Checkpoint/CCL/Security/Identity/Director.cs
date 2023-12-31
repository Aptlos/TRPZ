namespace CCL.Security.Identity;

public class Director : User
{
    public Director(int userId, string userName, int reasonId) : base(userId, userName, reasonId, nameof(Director))
    {
        
    }
}