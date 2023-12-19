using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl;

public class ReportRepository : BaseRepository<Report>, IReportRepository
{
    internal ReportRepository(ReportContext context)
        : base(context)
    {
    }
}