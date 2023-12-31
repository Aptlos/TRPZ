namespace CCL.Security.Identity;

public class Worker : User
{
    public Worker(int userId, string userName, int reasonId) : base(userId, userName,reasonId, nameof(Worker))
    {
        
    }
}