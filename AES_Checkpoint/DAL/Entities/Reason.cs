namespace DAL.Entities;

public class Reason
{
    public int idReasons { get; set; }
    public string description { get; set; }
    public double fine { get; set; }
    public IEnumerable<Report> Reports { get; set; }
}