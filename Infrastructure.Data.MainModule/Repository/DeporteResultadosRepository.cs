using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class DeporteResultadosRepository : GenericRepository<DeporteResultados, int>, IDeporteResultadosRepository
    {
        public DeporteResultadosRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
