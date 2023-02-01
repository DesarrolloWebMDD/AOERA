using System;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto;
using Application.Dto.Security;
using Application.MainModule.Interface;
using Application.Security.Entity;
using Application.Security.ExternalFunctions;
using Application.Security.IJsonWebToken;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Infrastructure.CrossCutting.Constants;
using Infrastructure.CrossCutting.CustomExections;
using Microsoft.EntityFrameworkCore;

namespace Application.MainModule
{
    public class SecurityAppService : BaseAppService, ISecurityAppService
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly ILogSessionUserRepository _logSessionUserRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public SecurityAppService(IServiceProvider serviceProvider,
            IUsuarioRepository usuarioRepository,
            ILogSessionUserRepository logSessionUserRepository,
            IJwtFactory jwtFactory) : base(serviceProvider)
        {
            _usuarioRepository = usuarioRepository;
            _logSessionUserRepository = logSessionUserRepository;
            _jwtFactory = jwtFactory;
        }

        #region Public Methods

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto login)
        {
            var userDomain = await _usuarioRepository
                .Find(p => p.UserName == login.Username && p.Estado == HelperConst.EstadoActivo)
                .Include(p => p.UsuarioPunto)
                .FirstOrDefaultAsync();

            if (userDomain is null)
                throw new ControlledException(MessageConst.UsuarioIngresadoNoExiste);

            if (!(!string.IsNullOrEmpty(login.Password) &&
                  userDomain.Clave.Equals(EncriptFunction.Encriptar(login.Password))))
                throw new ControlledException(MessageConst.CredencialesIncorrectas);

            var claimsJwt = Mapper.Map<AppUser>(userDomain);
            //claimsJwt.Platform = login.Platform;
            var token = _jwtFactory.GetJwt(claimsJwt);
            var user = Mapper.Map<UserDto>(userDomain);
            await RegisterUserLogin(claimsJwt);

            var loginResponse = Mapper.Map<LoginResponseDto>(token);
            loginResponse.User = user;
            return loginResponse;
        }

        #endregion

        #region Private Methods

        private async Task RegisterUserLogin(AppUser user)
        {
            await _logSessionUserRepository.AddAsync(new LogSessionUser
            {
                UserId = user.Id,
                //Platform = user.Platform,
                LoginDate = DateTime.Now
            });
        }

        #endregion
    }
}