using System.Linq;
using Domain.MainModule.Entity;

namespace Domain.MainModule.IRepository
{
    public interface IMaestroDetalleRepository : IRepository<MaestroDetalle, int>
    {
        IQueryable<MaestroDetalle> GetActiveItemsMaster(string masterKey);
        IQueryable<MaestroDetalle> GetActiveItemsMaster(string masterKey, string detailKey);
    }
}