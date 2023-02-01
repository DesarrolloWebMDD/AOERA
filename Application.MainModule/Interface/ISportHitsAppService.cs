using Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.MainModule.Interface
{
    public interface ISportHitsAppService :  IBaseAppService<SportHitsDto>
    {
        Task<List<SportHitsDto>> GetHitsByUserId(int userId);
    }
}
