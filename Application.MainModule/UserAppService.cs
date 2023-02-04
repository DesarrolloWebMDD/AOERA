using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto;
using Application.MainModule.Interface;
using Application.Security.ExternalFunctions;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Domain.MainModule.Validations;
using FluentValidation.Results;
using Infrastructure.CrossCutting.Constants;
using Infrastructure.CrossCutting.CustomExections;
using Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RazorEngine;
using RazorEngine.Templating;

namespace Application.MainModule
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailHelper _emailHelper;
        private readonly IConfiguracionCorreoRepository _configuracionCorreoRepository;
        private readonly IMaestroDetalleRepository _maestroDetalleRepository;
        private readonly IMaestroRepository _maestroRepository;
        public UserAppService(IServiceProvider serviceProvider,
            IUsuarioRepository usuarioRepository, IConfiguration configuration,
             IMaestroRepository maestroRepository,
            IMaestroDetalleRepository maestroDetalleRepository,
            IEmailHelper emailHelper, IConfiguracionCorreoRepository configuracionCorreoRepository) : base(serviceProvider)

        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _emailHelper = emailHelper;
            _configuracionCorreoRepository = configuracionCorreoRepository;
            _maestroRepository = maestroRepository;
            _maestroDetalleRepository = maestroDetalleRepository;
        }

        public async Task<List<UserDto>> All()
        {
            var result = await _usuarioRepository.All().ToListAsync();
            return Mapper.Map<List<UserDto>>(result);
        }

        public async Task<ValidationResult> Create(UserDto templateDto)
        {
            UnitOfWork.BeginTransaction();
            //#region guardar imagen en otra ruta
            //if (!string.IsNullOrEmpty(templateDto.Base64Image))
            //{
            //    string ext = Path.GetExtension(templateDto.ImgName);
            //    var path = _configuration.GetSection("FileRepository:WritePath").Value;
            //    var key = Guid.NewGuid();
            //    templateDto.KeyName = key + ext;
            //    var fileBytes =
            //        Convert.FromBase64String(templateDto.Base64Image.Substring(templateDto.Base64Image.LastIndexOf(',') + 1));
            //    await using var stream =
            //        new FileStream($"{path}{templateDto.KeyName}", FileMode.Create, FileAccess.Write);
            //    stream.Write(fileBytes);
            //}
            //#endregion

            if (string.IsNullOrEmpty(templateDto.Password))
            {
                throw new ControlledException("Debe Ingresar la Contraseña o Clave");
            }

            var map = Mapper.Map<Usuario>(templateDto);
            map.Estado = HelperConst.EstadoActivo;
            map.CodigoReferencia = "USR-001";//GenerateReferenceCode().Result;
            map.Clave = EncriptFunction.Encriptar(templateDto.Password);
            

            var validateResult = await _usuarioRepository.AddAsync(map, new UserValidator(_usuarioRepository, 1));
            if (validateResult.IsValid)
            await UnitOfWork.SaveChangesAsync();
            await SendMailRegister(templateDto);
            return validateResult;
        }

        public async Task<UserDto> GetById(int id)
        {
            var path = _configuration.GetSection("FileRepository:ReadPath").Value;
            var userDomain = await _usuarioRepository.Find(x => x.Id == id)
                .FirstOrDefaultAsync();
            userDomain.KeyImagen = $"{path}{userDomain.KeyImagen}";
            var data = Mapper.Map<UserDto>(userDomain);
            data.Password = EncriptFunction.Desencriptar(userDomain.Clave);
            return data;
        }

        public Task<List<UserDto>> ListAllStatus()
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> Update(UserDto entidad)
        {
            UnitOfWork.BeginTransaction();

            var entity = await _usuarioRepository.Find(x => x.Id == entidad.Id)
                //.Include(r => r.RolList)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ControlledException("El usuario que desea actualizar no fue encontrado ...!");
            }

            if (entidad.Indicador > 0)
            {
                string ext = Path.GetExtension(entidad.ImgName);
                var key = Guid.NewGuid();
                entidad.KeyName = key + ext;
                var path = _configuration.GetSection("FileRepository:WritePath").Value;
                var fileBytes =
                    Convert.FromBase64String(entidad.Base64Image.Substring(entidad.Base64Image.LastIndexOf(',') + 1));
                await using var stream =
                    new FileStream($"{path}{entidad.KeyName}", FileMode.Create, FileAccess.Write);
                stream.Write(fileBytes);
            }
            else
            {
                entidad.KeyName = entity.KeyImagen;
            }
            var entidadUpdate = Mapper.Map(entidad, entity);
            entidadUpdate.Clave = EncriptFunction.Encriptar(entidad.Password);

            var validateResult =
                await _usuarioRepository.UpdateAsync(entidadUpdate, new UserValidator(_usuarioRepository, 2));
            if (validateResult.IsValid)
                await UnitOfWork.SaveChangesAsync();
            return validateResult;
        }

        public async Task<ValidationResult> UpdateState(EstadoDto<int> state)
        {
            UnitOfWork.BeginTransaction();
            var entity = await _usuarioRepository.GetAsync(state.Id);
            entity.Estado = state.Status ? HelperConst.EstadoActivo : HelperConst.EstadoInactivo;
            var validateResult = await _usuarioRepository.UpdateAsync(entity);
            if (validateResult.IsValid)
                await UnitOfWork.SaveChangesAsync();
            return validateResult;
        }

       
        #region Private Method 
        private async Task<Usuario> GetUsertEntity(string dni, string usuario)
        {
            var entity = await _usuarioRepository
                .Find(p => p.DNI == dni && p.UserName == usuario).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new ControlledException("Usuario no encontrado ...!");
            }

            return entity;
        }

        private async Task SendMailRegister(UserDto user)
        {
            var entity = await GetUsertEntity(user.DocumentNumber, user.UserName);
            var emailSetting = _configuracionCorreoRepository.Find(x => x.Nombre == "EMAIL_USER_REGISTER").Single();
            var result = Engine.Razor.RunCompile(emailSetting.Cuerpo, "templateKey", null, entity);

            await _emailHelper.Send(new Email
            {
                Subject = emailSetting.Asunto,
                AddressList = new List<string> { user.Mail },
                Body = result
            });
        }

        private async Task<string> GenerateReferenceCode()
        {
            int correlative = 0;
            DateTime date = DateTime.Now;
            var entity = _maestroDetalleRepository
                .Find(
                    p => p.Activo == HelperConst.EstadoActivo &&
                         p.Maestro.Clave == MasterConst.KeyCodeReference, false).FirstOrDefault();

            if (entity != null)
            {
                correlative = Convert.ToInt32(entity.Valor) + 1;
                entity.Valor = correlative.ToString();
            }
            else
            {
                correlative++;
                var master = _maestroRepository.Find(p => p.Clave == MasterConst.KeyCodeReference).First();
                await _maestroDetalleRepository.AddAsync(new MaestroDetalle
                {
                    Clave = MasterConst.KeyCodeReferenceDetalle,
                    IdMaestro = master.Id,
                    Valor = $"{correlative:00000000}",
                    Activo = true
                });
            }

            await UnitOfWork.SaveChangesAsync();

            return $"{MasterConst.KeyCodeReferenceBase}{correlative:000000}";
        }
        #endregion
    }
}