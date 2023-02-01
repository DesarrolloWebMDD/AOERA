using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class AciertosRepository :  GenericRepository<Aciertos, int>, IAciertosRepository
    {
        public AciertosRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
