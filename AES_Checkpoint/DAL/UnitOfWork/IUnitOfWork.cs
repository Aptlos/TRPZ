using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IReportRepository Reports { get; }
    IReasonRepository Reasons { get; }
    void Save();
}