using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class UsuarioPuntoRepository : GenericRepository<UsuarioPunto, int>, IUsuarioPuntoRepository
    {
        public UsuarioPuntoRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
