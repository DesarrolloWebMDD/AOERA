using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.Security;
using Application.MainModule.Interface;
using Infrastructure.CrossCutting.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Distributed.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private readonly ISecurityAppService _securityAppService;

        public UserController(IUserAppService userAppService, ISecurityAppService securityAppService)
        {
            _userAppService = userAppService;
            _securityAppService = securityAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(UserDto entidad)
        {
            var result = await _userAppService.Create(entidad);
            return new OkObjectResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto entidad)
        {
            var result = await _userAppService.Update(entidad);
            return new OkObjectResult(result);
        }

        [HttpGet("All")]
        public IActionResult All()
        {
            var result = _userAppService.All();
            return new OkObjectResult(new JsonResult<List<UserDto>>(result.Result));
        }

        [HttpPut("updateStatus")]
        public async Task<IActionResult> UpdateState(EstadoDto<int> estado)
        {
            var resultado = await _userAppService.UpdateState(estado);
            return new OkObjectResult(resultado);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _userAppService.GetById(id);
            return new OkObjectResult(new JsonResult<UserDto>(result));
        }

     
        /// <summary>
        /// Permite acceso al sistema, se genera un token de acceso
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Access")]
        public async Task<IActionResult> Login(LoginRequestDto login)
        {
            var result = await _securityAppService.LoginAsync(login);
            return new OkObjectResult(new JsonResult<LoginResponseDto>(result));
        }

    }
}