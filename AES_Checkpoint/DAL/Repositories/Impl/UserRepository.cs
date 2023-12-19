using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    internal UserRepository(ReportContext context)
        : base(context)
    {
    }
}