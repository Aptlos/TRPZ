using lab7.Repositories.Interfaces;

namespace lab7.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IReportRepository Reports { get; }
    IUserRepository Users { get; }
    void Save();
}