using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl;

public class ReasonRepository : BaseRepository<Reason>, IReasonRepository
{
    internal ReasonRepository(ReportContext context)
        : base(context)
    {
    }
}