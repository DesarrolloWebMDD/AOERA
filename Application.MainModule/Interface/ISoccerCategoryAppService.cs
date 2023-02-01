using Application.Dto;
using System.Threading.Tasks;

namespace Application.MainModule.Interface
{
    public interface ISoccerCategoryAppService : IBaseAppService<SoccerCategoryDto>
    {
        Task<MenuCategoryBetDto> GetListMenu();
    }
}
