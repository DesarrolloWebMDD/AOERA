using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class LigasRepository : GenericRepository<Ligas, int>, ILigasRepository
    {
        public LigasRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
