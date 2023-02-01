using System.Threading.Tasks;

namespace Domain.MainModule.IUnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveChangesAsync();
        void BeginTransaction();
    }
}