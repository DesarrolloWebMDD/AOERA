using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class PuntosPaqueteRepository : GenericRepository<PuntosPaquete, int>, IPuntosPaqueteRepository
    {
        public PuntosPaqueteRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
