namespace DAL.Entities;

public class User
{
    public int idUsers { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
    public IEnumerable<Report> Reports { get; set; }
}