using System.Linq;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class MaestroDetalleRepository : GenericRepository<MaestroDetalle, int>, IMaestroDetalleRepository
    {
        public MaestroDetalleRepository(MainContext mainContext) : base(mainContext)
        {
        }

        public IQueryable<MaestroDetalle> GetActiveItemsMaster(string masterKey)
        {
            return Find(p => p.Maestro.Clave == masterKey && p.Activo);
        }

        public IQueryable<MaestroDetalle> GetActiveItemsMaster(string masterKey, string detailKey)
        {
            return Find(p =>
                p.Maestro.Descripcion == masterKey && p.Descripcion == detailKey && p.Activo);
        }
    }
}