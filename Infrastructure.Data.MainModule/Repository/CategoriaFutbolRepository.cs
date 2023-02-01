using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class CategoriaFutbolRepository : GenericRepository<CategoriaFutbol, int>, ICategoriaFutbolRepository
    {
        public CategoriaFutbolRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
