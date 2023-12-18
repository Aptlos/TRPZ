using lab7.EF;
using lab7.Entities;
using lab7.Repositories.Interfaces;

namespace lab7.Repositories.Impl;

public class ReportRepository : BaseRepository<Report>, IReportRepository
{
    internal ReportRepository(ReportContext context)
        : base(context)
    {
    }
}