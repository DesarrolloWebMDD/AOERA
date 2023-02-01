using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class PagoComprasRepository : GenericRepository<PagoCompras, int>, IPagoComprasRepository
    {
        public PagoComprasRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
