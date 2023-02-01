using Application.Dto;
using Application.MainModule.Interface;
using Infrastructure.CrossCutting.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Distributed.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigueController : ControllerBase
    {
        private readonly ILigueAppService _ligueAppService;
        public LigueController(ILigueAppService ligueAppService)
        {
            _ligueAppService = ligueAppService;
        }
        [HttpGet("listLigues")]
        public IActionResult ListLigues()
        {
            var result = _ligueAppService.ListAllStatus();
            return new OkObjectResult(new JsonResult<List<LigueDto>>(result.Result));
        }
    }
}
