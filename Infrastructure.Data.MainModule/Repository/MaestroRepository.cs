using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class MaestroRepository : GenericRepository<Maestro, int>, IMaestroRepository
    {
        public MaestroRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}