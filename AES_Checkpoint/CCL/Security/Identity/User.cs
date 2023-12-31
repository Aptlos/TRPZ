namespace CCL.Security.Identity;

public abstract class User
{
    public int idUser { get; }
    public string UserName { get; }
    protected string UserRole { get; }
    public User(int idUsers, string userName, string userRole)
    {
        idUser = idUsers;
        UserName = userName;
        UserRole = userRole;
    }
}