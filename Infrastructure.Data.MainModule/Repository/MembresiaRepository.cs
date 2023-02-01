using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class MembresiaRepository : GenericRepository<Membresia, int>, IMembresiaRepository
    {
        public MembresiaRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
