using Application.Core;
using Application.Dto;
using Application.MainModule.Interface;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Domain.MainModule.Validations;
using FluentValidation.Results;
using Infrastructure.CrossCutting.Constants;
using Infrastructure.CrossCutting.CustomExections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MainModule
{
    public class SportHitsAppService : BaseAppService, ISportHitsAppService
    {
        private readonly IAciertosRepository _aciertosRepository;
        private readonly IUsuarioPuntoRepository _usuarioPuntoRepository;
        private readonly IMaestroRepository _maestroRepository;
        private readonly IMaestroDetalleRepository _maestroDetalleRepository;
        
        public SportHitsAppService(IServiceProvider serviceProvider,
            IAciertosRepository aciertosRepository,
            IUsuarioPuntoRepository usuarioPuntoRepository,
            IMaestroRepository maestroRepository,
            IMaestroDetalleRepository maestroDetalleRepository) : base(serviceProvider)
        {
            _aciertosRepository = aciertosRepository;
            _usuarioPuntoRepository = usuarioPuntoRepository;
            _maestroRepository = maestroRepository;
            _maestroDetalleRepository = maestroDetalleRepository;
        }

        public Task<List<SportHitsDto>> All()
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> Create(SportHitsDto entidad)
        {
            UnitOfWork.BeginTransaction();

            var userPoints = await _usuarioPuntoRepository.Find(x => x.UsuarioId == entidad.UserId, false).FirstOrDefaultAsync();
            var puntosTotales = (userPoints.PuntosMembresia) + (userPoints.PuntosRecarga == null? 0 : userPoints.PuntosRecarga);
            
            if(entidad.PointsHit > puntosTotales)
            {
                throw new ControlledException("Error: no tiene puntos suficientes ...!");
            }
            entidad.HitType = entidad.SportHitsDetails.Count > 1 ? 1 : 2;
            var map = Mapper.Map<Aciertos>(entidad);
            map.FechaCreado = DateTime.Now;
            map.Estado = HelperConst.EstadoActivo;
            map.Codigo = GenerateReferenceCode().Result;
            var validateResult = await _aciertosRepository.AddAsync(map, new SportHitsValidator(_aciertosRepository));
            if (!validateResult.IsValid)
            {
                throw new ControlledException("Error: la operacion crear apuesta fallida ...!");
            }
            else
            {
                userPoints.PuntosMembresia = (userPoints.PuntosMembresia - entidad.PointsHit);
                await UnitOfWork.SaveChangesAsync();
            }

            
            return validateResult;
        }

        public Task<SportHitsDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SportHitsDto>> GetHitsByUserId(int userId)
        {
            var result = await _aciertosRepository.Find(x => x.UserId == userId)
                .Include(d => d.DetalleAciertos).Take(10).OrderByDescending(x => x.Id)
                .ToListAsync();
            return Mapper.Map<List<SportHitsDto>>(result);
        }

        public Task<List<SportHitsDto>> ListAllStatus()
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Update(SportHitsDto entidad)
        {
            throw new NotImplementedException();
        }


        #region  methos private

        private async Task<string> GenerateReferenceCode()
        {
            int correlative = 0;
            DateTime date = DateTime.Now;
            var entity = _maestroDetalleRepository
                .Find(
                    p => p.Activo == HelperConst.EstadoActivo &&
                         p.Maestro.Clave == MasterConst.CodigoAciertoUser, false).FirstOrDefault();

            if (entity != null)
            {
                correlative = Convert.ToInt32(entity.Valor) + 1;
                entity.Valor = correlative.ToString();
            }
            else
            {
                correlative++;
                var master = _maestroRepository.Find(p => p.Clave == MasterConst.CodigoAciertoUser).First();
                await _maestroDetalleRepository.AddAsync(new MaestroDetalle
                {
                    Clave = "ACF",
                    IdMaestro = master.Id,
                    Valor = "0",
                    Activo = true
                });
            }

            await UnitOfWork.SaveChangesAsync();

            return $"{entity.Clave}{correlative:00000}";
        }
        #endregion
    }
}
