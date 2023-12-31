namespace CCL.Security.Identity;

public class Worker : User
{
    public Worker(int userId, string userName) : base(userId, userName, nameof(Worker))
    {
        
    }
}