using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class DeportesRepository : GenericRepository<Deportes, int>, IDeportesRepository
    {
        public DeportesRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
