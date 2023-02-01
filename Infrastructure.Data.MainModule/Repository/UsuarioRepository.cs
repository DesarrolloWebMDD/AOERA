using System.Linq;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.Data.MainModule.Context;

namespace Infrastructure.Data.MainModule.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(MainContext mainContext) : base(mainContext)
        {
        }

        public IQueryable<Usuario> FindByEmail(string email)
        {
            return Find(p => p.Email == email);
        }

        public IQueryable<Usuario> FindById(int userId)
        {
            return Find(p => p.Id == userId);
        }
    }
}