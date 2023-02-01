using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;

namespace Application.MainModule.Interface
{
    public interface IMasterDetailAppService
    {
        Task<List<MasterDetailDto>> ItemsMasterDetails(string key);
    }
}