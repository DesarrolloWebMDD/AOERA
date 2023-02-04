using System.Threading.Tasks;
using Application.Dto;
using FluentValidation.Results;

namespace Application.MainModule.Interface
{
    public interface IUserAppService : IBaseAppService<UserDto>
    {
        Task<ValidationResult> UpdateState(EstadoDto<int> state);
    }
}