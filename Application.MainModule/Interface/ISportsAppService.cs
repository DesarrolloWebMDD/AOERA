using Application.Dto;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.MainModule.Interface
{
    public interface ISportsAppService : IBaseAppService<SportsDto>
    {
        Task<ValidationResult> AddSports(UploadFileDto request);
        Task<List<SportsDto>> ListSportsDay();
        Task<List<SportsListDto>> ListSportsState(int? state);
        Task<ValidationResult> SportsResultCreate();
        Task<List<SportResultDto>> ListSportsResult(int sportId);
    }
}
