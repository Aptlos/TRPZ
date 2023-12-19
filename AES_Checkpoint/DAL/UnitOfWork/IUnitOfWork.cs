using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IReportRepository Reports { get; }
    IUserRepository Users { get; }
    void Save();
}