using lab7.EF;
using lab7.Entities;
using lab7.Repositories.Interfaces;

namespace lab7.Repositories.Impl;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    internal UserRepository(ReportContext context)
        : base(context)
    {
    }
}