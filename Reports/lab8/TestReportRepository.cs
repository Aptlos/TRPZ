using lab7.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace lab8;

public class TestReportRepository : BaseRepository<DbContext>
{
    public TestReportRepository(DbContext context)
        : base(context)
    {
    }
}