using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class ConfiguracionCorreoRepository : GenericRepository<ConfiguracionCorreo, int>, IConfiguracionCorreoRepository
    {
        public ConfiguracionCorreoRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
