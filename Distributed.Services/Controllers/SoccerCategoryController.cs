using Application.Dto;
using Application.MainModule.Interface;
using Infrastructure.CrossCutting.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Distributed.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoccerCategoryController : ControllerBase
    {
        private readonly ISoccerCategoryAppService _soccerCategoryAppService;
        public SoccerCategoryController(ISoccerCategoryAppService soccerCategoryAppService)
        {
            _soccerCategoryAppService = soccerCategoryAppService;
        }

        [HttpGet("listMenu")]
        public IActionResult ListMenu()
        {
            var result = _soccerCategoryAppService.GetListMenu();
            return new OkObjectResult(new JsonResult<MenuCategoryBetDto>(result.Result));
        }
    }
}
