using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Application.MainModule.Interface
{
    public interface IBaseAppService<Entidad> where Entidad : class
    {
        Task<ValidationResult> Create(Entidad templateDto);
        Task<ValidationResult> Update(Entidad entidad);
        Task<Entidad> GetById(int id);
        Task<List<Entidad>> All();
        Task<List<Entidad>> ListAllStatus();
    }
}