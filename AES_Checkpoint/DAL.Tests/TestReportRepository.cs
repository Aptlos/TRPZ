using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests;

public class TestReportRepository : BaseRepository<Report>
{
    public TestReportRepository(DbContext context)
        : base(context)
    {
    }
}