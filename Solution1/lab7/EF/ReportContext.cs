using lab7.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab7.EF;

public class ReportContext : DbContext
{
    public DbSet<User> Phones { get; set; }
    public DbSet<Report> Orders { get; set; }
    public ReportContext(DbContextOptions options)
        : base(options)
    {
    }
}