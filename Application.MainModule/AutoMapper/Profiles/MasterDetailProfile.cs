using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class MasterDetailProfile : Profile
    {
        public MasterDetailProfile()
        {
            CreateMap<MaestroDetalle, MasterDetailDto>()
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.Key, m => m.MapFrom(d => d.Clave))
                .ForMember(x => x.Value, m => m.MapFrom(d => d.Valor))
                .ForMember(x => x.Description, m => m.MapFrom(d => d.Descripcion))
                .ForMember(x => x.State, m => m.MapFrom(d => d.Activo))
                .ForMember(x => x.MasterId, m => m.MapFrom(d => d.IdMaestro))
                .ReverseMap();
        }
    }
}