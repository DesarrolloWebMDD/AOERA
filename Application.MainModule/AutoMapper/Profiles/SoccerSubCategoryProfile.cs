using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class SoccerSubCategoryProfile : Profile
    {
        public SoccerSubCategoryProfile()
        {
            CreateMap<FutbolSubCagoria, SoccerSubCategoryDto>()
               .ForMember(p => p.SoccerCategoryId, q => q.MapFrom(r => r.CategoriaFutbolId))
               .ForMember(p => p.Name, q => q.MapFrom(r => r.Nombre))
               .ForMember(p => p.Description, q => q.MapFrom(r => r.Descripcion))
               .ForMember(p => p.State, q => q.MapFrom(r => r.Estado))
               .ForMember(p => p.Ligues, q => q.MapFrom(r => r.Ligas))
               .ReverseMap();
        }
    }
}
