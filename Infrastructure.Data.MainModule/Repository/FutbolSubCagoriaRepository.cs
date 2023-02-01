using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class FutbolSubCagoriaRepository : GenericRepository<FutbolSubCagoria, int>, IFutbolSubCagoriaRepository
    {
        public FutbolSubCagoriaRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
