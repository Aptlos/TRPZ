using lab7.Entities;
using lab7.Repositories.Impl;
using lab7.Repositories.Interfaces;
using lab7.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace lab7.EF;

public class EFUnitOfWork
    : IUnitOfWork
{
    private ReportContext db;
    private ReportRepository reportRepository;
    private UserRepository userRepository;

    public EFUnitOfWork(DbContextOptions options)
    {
        db = new ReportContext(options);
    }

    public IReportRepository Reports
    {
        get
        {
            if (reportRepository == null)
                reportRepository = new ReportRepository(db);
            return reportRepository;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (userRepository == null)
                userRepository = new UserRepository(db);
            return userRepository;
        }
    }

    public void Save()
    {
        db.SaveChanges();
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }

            this.disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
