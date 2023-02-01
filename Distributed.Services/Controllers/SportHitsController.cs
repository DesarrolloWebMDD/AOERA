using Application.Dto;
using Application.MainModule.Interface;
using Infrastructure.CrossCutting.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Distributed.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportHitsController : BaseController
    {
        private readonly ISportHitsAppService _sportHitsAppService;

        public SportHitsController(ISportHitsAppService sportHitsAppService)
        {
            _sportHitsAppService = sportHitsAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SportHitsDto entidad)
        {
            var result = await _sportHitsAppService.Create(entidad);
            return new OkObjectResult(result);
        }

        [HttpGet("getHitsByUserId/{userId}")]
        public IActionResult GetHitsByUserId(int userId)
        {
            var result = _sportHitsAppService.GetHitsByUserId(userId);
            return new OkObjectResult(new JsonResult<List<SportHitsDto>>(result.Result));
        }

    }
}
