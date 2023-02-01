using System.Threading.Tasks;
using Application.Dto.Security;

namespace Application.MainModule.Interface
{
    public interface ISecurityAppService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto login);
    }
}