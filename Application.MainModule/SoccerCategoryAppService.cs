using Application.Core;
using Application.Dto;
using Application.MainModule.Interface;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using FluentValidation.Results;
using Infrastructure.CrossCutting.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MainModule
{
    public class SoccerCategoryAppService : BaseAppService, ISoccerCategoryAppService
    {
        private readonly ICategoriaFutbolRepository _categoriaFutbolRepository;
        private readonly ILigasRepository _ligasRepository;
        public SoccerCategoryAppService(IServiceProvider serviceProvider,
            ICategoriaFutbolRepository categoriaFutbolRepository, ILigasRepository ligasRepository) : base(serviceProvider)
        {
            _categoriaFutbolRepository = categoriaFutbolRepository;
            _ligasRepository = ligasRepository;
        }

        public async Task<List<SoccerCategoryDto>> All()
        {
            throw new NotImplementedException();
         
        }

        public Task<ValidationResult> Create(SoccerCategoryDto templateDto)
        {
            throw new NotImplementedException();
        }

        public Task<SoccerCategoryDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MenuCategoryBetDto> GetListMenu()
        {
            var result = new MenuCategoryBetDto();
            var lstSuccessCategory = await _categoriaFutbolRepository.Find(x => x.Estado == HelperConst.EstadoActivo)
             .Include(x => x.FutbolSubCagorias.Where(c => c.Estado == HelperConst.EstadoActivo))
             .ToListAsync();


            var lstLigues = await _ligasRepository.Find(x => x.Estado == HelperConst.EstadoActivo).ToListAsync();
            var lstLiguesOutstanding = await _ligasRepository.Find(x => x.Estado == HelperConst.EstadoActivo && x.Destacado == true).ToListAsync();

            foreach (var item in lstSuccessCategory)
            {
                foreach (var item2 in item.FutbolSubCagorias)
                {
                    var lista = lstLigues.Where(x => x.FutbolSubCagoriaId == item2.Id).ToList();
                    item2.Ligas = Mapper.Map<List<Ligas>>(lista);
                }
            }

            result.SoccerCategorys = Mapper.Map<List<SoccerCategoryDto>>(lstSuccessCategory);
            result.LigueOutstanding = Mapper.Map<List<LigueDto>>(lstLiguesOutstanding);
            return result;
        }

        public Task<List<SoccerCategoryDto>> ListAllStatus()
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Update(SoccerCategoryDto entidad)
        {
            throw new NotImplementedException();
        }
    }
}
