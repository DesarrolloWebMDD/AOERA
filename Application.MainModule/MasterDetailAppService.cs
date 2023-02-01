using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto;
using Application.MainModule.Interface;
using Domain.MainModule.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Application.MainModule
{
    public class MasterDetailAppService : BaseAppService, IMasterDetailAppService
    {
        private readonly IMaestroDetalleRepository _maestroDetalleRepository;

        public MasterDetailAppService(IServiceProvider serviceProvider,
            IMaestroDetalleRepository maestroDetalleRepository) : base(serviceProvider)
        {
            _maestroDetalleRepository = maestroDetalleRepository;
        }

        public async Task<List<MasterDetailDto>> ItemsMasterDetails(string key)
        {
            var resul = await _maestroDetalleRepository.GetActiveItemsMaster(key).ToListAsync();
            return Mapper.Map<List<MasterDetailDto>>(resul);
        }
    }
}