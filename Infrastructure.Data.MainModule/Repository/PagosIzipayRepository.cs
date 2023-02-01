using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class PagosIzipayRepository : GenericRepository<PagosIzipay, int>, IPagosIzipayRepository
    {
        public PagosIzipayRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
