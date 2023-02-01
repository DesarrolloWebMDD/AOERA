using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class SportResultProfile : Profile
    {
        public SportResultProfile()
        {
            CreateMap<DeporteResultados, SportResultDto>()
           .ForMember(p => p.SportId, q => q.MapFrom(r => r.DeporteId))
           .ForMember(p => p.TypeText, q => q.MapFrom(r => r.TextoTipo))
           .ForMember(p => p.ExtraValue, q => q.MapFrom(r => r.ValorExtra))
           .ForMember(p => p.PointResult, q => q.MapFrom(r => r.PuntoResultado))
           .ForMember(p => p.TypeResult, q => q.MapFrom(r => r.TipoResultado))
           .ForMember(p => p.Result, q => q.MapFrom(r => r.Resultado))
           .ForMember(p => p.State, q => q.MapFrom(r => r.Estado))
           .ForMember(p => p.Sport, q => q.MapFrom(r => r.Deporte))
           .ReverseMap();
        }
    }
}
