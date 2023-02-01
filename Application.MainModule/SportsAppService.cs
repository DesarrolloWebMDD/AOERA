using Application.Core;
using Application.Dto;
using Application.MainModule.Interface;
using Application.MainModule.Util;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using Domain.MainModule.Validations;
using FluentValidation.Results;
using Infrastructure.CrossCutting.Constants;
using Infrastructure.CrossCutting.CustomExections;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.MainModule
{
    public class SportsAppService : BaseAppService, ISportsAppService
    {
        ExcelReader _readExcel = new ExcelReader();
        private readonly IConfiguration _configuration;
        private readonly IDeportesRepository _deportesRepository;
        private readonly IDeporteResultadosRepository _deporteResultadosRepository;
        public SportsAppService(IServiceProvider serviceProvider,
            IConfiguration configuration, IDeportesRepository deportesRepository,
            IDeporteResultadosRepository deporteResultadosRepository) : base(serviceProvider)
        {
            _configuration = configuration;
            _deportesRepository = deportesRepository;
            _deporteResultadosRepository = deporteResultadosRepository;
        }
        public async Task<ValidationResult> AddSports(UploadFileDto request)
        {
            var validateResult = new ValidationResult();
            var path = _configuration.GetSection("FileRepository:WritePath").Value;
            var Lista = _readExcel.ReadExcelSports(request, path);
            if (Lista != null)
            {
                validateResult = await SaveSport(Lista, request.LigueId);
            }
            await UnitOfWork.SaveChangesAsync();
            return validateResult;
        }

        public Task<List<SportsDto>> All()
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Create(SportsDto templateDto)
        {
            throw new NotImplementedException();
        }

        public Task<SportsDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SportsDto>> ListAllStatus()
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> Update(SportsDto entidad)
        {
            var deporDomain = await _deportesRepository.GetAsync(entidad.Id);

            entidad.Hour = deporDomain.Hora;
            entidad.DateHour = deporDomain.FechaHora;
            entidad.DeportText = deporDomain.EquiposReviales;
            entidad.TeamA = deporDomain.EquipoA;
            entidad.TeamB = deporDomain.EquipoB;
            entidad.PointA = deporDomain.PuntoA;
            entidad.PointB = deporDomain.PuntoB;
            entidad.TieText = deporDomain.EmpateTexto;
            entidad.PointTie = deporDomain.EmpatePunto;
            entidad.Goal1Text = deporDomain.Gol1Text;
            entidad.PointGoal1 = deporDomain.PuntoGol1;
            entidad.Goal2Text = deporDomain.Gol2Text;
            entidad.PointGoal2 = deporDomain.PuntoGol2;
            entidad.Goal3Text = deporDomain.Gol3Text;
            entidad.PointGoal3 = deporDomain.PuntoGol3;
            entidad.Goal4Text = deporDomain.Gol4Text;
            entidad.PointGoal4 = deporDomain.PuntoGol4;
            entidad.Goal_1Text = deporDomain.Gol_1Text;
            entidad.PointGoal_1 = deporDomain.PuntoGol_1;
            entidad.Goal_2Text = deporDomain.Gol_2Text;
            entidad.PointGoal_2 = deporDomain.PuntoGol_2;
            entidad.Goal_3Text = deporDomain.Gol_3Text;
            entidad.PointGoal_3 = deporDomain.PuntoGol_3;
            entidad.Goal_4Text = deporDomain.Gol_4Text;
            entidad.PointGoal_4 = deporDomain.PuntoGol_4;
            entidad.TeamLE = deporDomain.LocalEmpateTexto;
            entidad.PointLE = deporDomain.LocalEmpatePunto;
            entidad.TeamEV = deporDomain.EmpateVisitaTexto;
            entidad.PointEV = deporDomain.EmpateVisitaPunto;
            entidad.GoalSi = deporDomain.GolColSiTexto;
            entidad.PointSI = deporDomain.GolColSiPunto;
            entidad.GoalNo = deporDomain.GolColNoTexto;
            entidad.PointNO = deporDomain.GolColNoPunto;
            entidad.LigueId = deporDomain.LigaId;
            entidad.StateSport = HelperConst.Fenalizado;
            var entidadUpdate = Mapper.Map(entidad, deporDomain);
            var validateResult =
               await _deportesRepository.UpdateAsync(entidadUpdate, new DeporteValidator(_deportesRepository));
            if (validateResult.IsValid)

                await UnitOfWork.SaveChangesAsync();
            return validateResult;
        }
        public async Task<List<SportsDto>> ListSportsDay()
        {
            DateTime date = DateTime.Now;
            var result = await _deportesRepository.Find(x => x.FechaHora.Date == date.Date
            && x.EstadoJuego == HelperConst.EventosCreados && x.Estado == HelperConst.EstadoActivo).ToListAsync();
            return Mapper.Map<List<SportsDto>>(result);
        }

        public async Task<List<SportsListDto>> ListSportsState(int? state)
        {
            var predicate = PredicateBuilder.New<Deportes>();
            predicate.DefaultExpression = f => true;
            if (state == 0)
            {
                predicate = predicate.And(x => x.EstadoJuego != HelperConst.Pendiente && x.Estado == HelperConst.EstadoActivo);
            }
            else
            {
                predicate = predicate.And(x => x.EstadoJuego == state & x.Estado == HelperConst.EstadoActivo);
            }
            var result = await _deportesRepository.Find(predicate)
                .Include(p => p.Liga)
                .ToListAsync();
            return Mapper.Map<List<SportsListDto>>(result);
        }

        public async Task<ValidationResult> SportsResultCreate()
        {
            var lstDeportUpload = await _deportesRepository.Find(x => x.EstadoJuego == HelperConst.Pendiente).ToListAsync();
            var validateResult = new ValidationResult();
            if (lstDeportUpload.Count > 0)
            {
                foreach (var item in lstDeportUpload)
                {
                    var entity = await _deportesRepository.GetAsync(item.Id);
                    entity.EstadoJuego = HelperConst.EventosCreados;
                    entity.DeporteResultados = Mapper.Map<List<DeporteResultados>>(SportsResultCreate(item.Id));
                    validateResult = await _deportesRepository.UpdateAsync(entity);
                    if (!validateResult.IsValid)
                    {
                        throw new ControlledException("Error: al crear eventos ...!");
                    }
                }
            }
            else
            {
                throw new ControlledException("Asistente: no hay eventos por crear ...!");
            }
            if (validateResult.IsValid)
            {
                await UnitOfWork.SaveChangesAsync();
            }
            return validateResult;
        }


        public async Task<List<SportResultDto>> ListSportsResult(int sportId)
        {
            var lstDomailResult = await _deporteResultadosRepository.Find(x => x.DeporteId == sportId).ToListAsync();
            return Mapper.Map<List<SportResultDto>>(lstDomailResult);
        }

        #region  method private

        private async Task<ValidationResult> SaveSport(List<SportsDto> list, int ligaId)
        {
            var validateResult = new ValidationResult();
            foreach (var item in list)
            {
                var mapDeport = Mapper.Map<Deportes>(item);
                mapDeport.LigaId = ligaId;
                mapDeport.Estado = HelperConst.EstadoActivo;
                mapDeport.EstadoJuego = HelperConst.Pendiente;
                validateResult = await _deportesRepository.AddAsync(mapDeport, new DeporteValidator(_deportesRepository));
                if (!validateResult.IsValid)
                {
                    throw new ControlledException("Error: al cargar excel ...!");
                }
            }
            return validateResult;
        }

        private List<DeporteResultados> SportsResultCreate(int sportId)
        {
            var result = new List<DeporteResultados>();
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "L",
                ValorExtra = 0,
                PuntoResultado = 0,
                TipoResultado = HelperConst.Local,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "V",
                ValorExtra = 0,
                PuntoResultado = 0,
                TipoResultado = HelperConst.Visita,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "E",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Empate,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "+ 0.5",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Gol1,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "+ 1.5",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Gol2,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "+ 2.5",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Gol3,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "+ 3.5",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Gol4,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "- 0.5",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Gol_1,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "- 1.5",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Gol_2,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "- 2.5",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Gol_3,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "- 3.5",
                PuntoResultado = 0,
                TipoResultado = HelperConst.Gol_4,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "LE",
                PuntoResultado = 0,
                TipoResultado = HelperConst.LocalEmpate,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "EV",
                PuntoResultado = 0,
                TipoResultado = HelperConst.EmpateVisita,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "GG",
                PuntoResultado = 0,
                TipoResultado = HelperConst.GolGol,
                Resultado = false,
                Estado = true
            });
            result.Add(new DeporteResultados
            {
                DeporteId = sportId,
                TextoTipo = "NG",
                PuntoResultado = 0,
                TipoResultado = HelperConst.NoGol,
                Resultado = false,
                Estado = true
            });
            /**
            result.Add(new DeporteResultados
            {

            });
            result.Add(new DeporteResultados
            {

            });**/
            return result;
        }





        #endregion
    }
}
