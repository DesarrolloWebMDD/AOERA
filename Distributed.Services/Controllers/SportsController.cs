using Application.Dto;
using Application.MainModule.Interface;
using Infrastructure.CrossCutting.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distributed.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : BaseController
    {
        private readonly ISportsAppService _sportsAppService;
        public SportsController(ISportsAppService sportsAppService)
        {
            _sportsAppService = sportsAppService;
        }

        [HttpPost("guardarExcelSport")]
        public async Task<ActionResult> GuardarExcelSport(UploadFileDto request)
        {
            var result = await _sportsAppService.AddSports(request);
            return new OkObjectResult(result);
        }

        [AllowAnonymous]
        [HttpGet("listSportsDay")]
        public IActionResult ListSportsDay()
        {
            var result = _sportsAppService.ListSportsDay();
            return new OkObjectResult(new JsonResult<List<SportsDto>>(result.Result));
        }

      
        [HttpGet("listSportsState/{state}")]
        public IActionResult ListSportsState(int? state)
        {
            var result = _sportsAppService.ListSportsState(state);
            return new OkObjectResult(new JsonResult<List<SportsListDto>>(result.Result));
        }

        [HttpGet("crearResultEvent")]
        public async Task<ActionResult> CrearResultEvent()
        {
            var result = await _sportsAppService.SportsResultCreate();
            return new OkObjectResult(result);
        }

        [HttpGet("listSportsResult/{sportId}")]
        public IActionResult ListSportsResult(int sportId)
        {
            var result = _sportsAppService.ListSportsResult(sportId);
            return new OkObjectResult(new JsonResult<List<SportResultDto>>(result.Result));
        }

        [HttpPut]
        public async Task<IActionResult> Update(SportsDto entidad)
        {
            var result = await _sportsAppService.Update(entidad);
            return new OkObjectResult(result);
        }
    }
}
