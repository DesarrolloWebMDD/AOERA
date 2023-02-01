using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class DetalleAciertosRepository : GenericRepository<DetalleAciertos, int>, IDetalleAciertosRepository
    {
        public DetalleAciertosRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
