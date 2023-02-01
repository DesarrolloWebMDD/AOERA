using System.Collections.Generic;
using Application.Dto;
using Application.MainModule.Interface;
using Infrastructure.CrossCutting.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Distributed.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDetailController : BaseController
    {
        private readonly IMasterDetailAppService _masterDetailAppService;

        public MasterDetailController(IMasterDetailAppService masterDetailAppService)
        {
            _masterDetailAppService = masterDetailAppService;
        }

        [HttpGet("listManterDetail/{masterKey}")]
        public IActionResult listManterDetail(string masterKey)
        {
            var result = _masterDetailAppService.ItemsMasterDetails(masterKey);
            return new OkObjectResult(new JsonResult<List<MasterDetailDto>>(result.Result));
        }
    }
}