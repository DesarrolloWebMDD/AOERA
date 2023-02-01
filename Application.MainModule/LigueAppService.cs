using Application.Core;
using Application.Dto;
using Application.MainModule.Interface;
using Domain.MainModule.IRepository;
using FluentValidation.Results;
using Infrastructure.CrossCutting.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainModule
{
    public class LigueAppService : BaseAppService, ILigueAppService
    {
        private readonly ILigasRepository _ligasRepository;
        public LigueAppService(IServiceProvider serviceProvider,
            ILigasRepository ligasRepository) : base(serviceProvider)
        {
            _ligasRepository = ligasRepository;
        }

        public Task<List<LigueDto>> All()
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Create(LigueDto templateDto)
        {
            throw new NotImplementedException();
        }

        public Task<LigueDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LigueDto>> ListAllStatus()
        {
            var result = await _ligasRepository.Find(x => x.Estado == HelperConst.EstadoActivo).ToListAsync();
            return Mapper.Map<List<LigueDto>>(result);
        }

        public Task<ValidationResult> Update(LigueDto entidad)
        {
            throw new NotImplementedException();
        }
    }
}
