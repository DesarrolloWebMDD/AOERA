using Application.Core;
using Application.Dto;
using Application.MainModule.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.MainModule
{
    public class SportHitsDetailAppService : BaseAppService,ISportHitsDetailAppService
    {
        public SportHitsDetailAppService(IServiceProvider serviceProvider):base(serviceProvider)
        {

        }

        public Task<List<SportHitsDetailDto>> All()
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Create(SportHitsDetailDto templateDto)
        {
            throw new NotImplementedException();
        }

        public Task<SportHitsDetailDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SportHitsDetailDto>> ListAllStatus()
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Update(SportHitsDetailDto entidad)
        {
            throw new NotImplementedException();
        }
    }
}
