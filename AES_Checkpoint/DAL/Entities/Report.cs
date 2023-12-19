namespace DAL.Entities;

public class Report
{
    public int ReportId { get; set; }
    public int Creator { get; set; }
    public int Intruder { get; set; }
    public int Reason { get; set; }
}