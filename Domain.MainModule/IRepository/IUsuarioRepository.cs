using System.Linq;
using Domain.MainModule.Entity;

namespace Domain.MainModule.IRepository
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
        IQueryable<Usuario> FindById(int userId);
        IQueryable<Usuario> FindByEmail(string email);
    }
}