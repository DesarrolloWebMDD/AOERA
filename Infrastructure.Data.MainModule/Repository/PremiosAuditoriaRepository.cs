using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class PremiosAuditoriaRepository : GenericRepository<PremiosAuditoria, int>, IPremiosAuditoriaRepository
    {
        public PremiosAuditoriaRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
