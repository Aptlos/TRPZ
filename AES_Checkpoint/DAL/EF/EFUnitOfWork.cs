using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class EFUnitOfWork
    : IUnitOfWork
{
    private ReportContext db;
    private ReportRepository reportRepository;
    private ReasonRepository reasonRepository;

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

    public IReasonRepository Reasons
    {
        get
        {
            if (reasonRepository == null)
                reasonRepository = new ReasonRepository(db);
            return reasonRepository;
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
