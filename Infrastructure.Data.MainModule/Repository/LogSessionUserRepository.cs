using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class LogSessionUserRepository : GenericRepository<LogSessionUser, int>, ILogSessionUserRepository
    {
        public LogSessionUserRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}