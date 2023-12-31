namespace CCL.Security.Identity;

public abstract class User
{
    public int idUser { get; }
    public string UserName { get; }
    public int ReasonId { get; }
    protected string UserRole { get; }
    public User(int idUsers, string userName, int reasonId, string userRole)
    {
        idUser = idUsers;
        UserName = userName;
        UserRole = userRole;
        ReasonId = reasonId;
    }
}