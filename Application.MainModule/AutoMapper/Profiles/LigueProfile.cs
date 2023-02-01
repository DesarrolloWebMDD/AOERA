using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class LigueProfile : Profile
    {
        public LigueProfile()
        {
            CreateMap<Ligas, LigueDto>()
              .ForMember(p => p.Name, q => q.MapFrom(r => r.Nombre))
              .ForMember(p => p.Description, q => q.MapFrom(r => r.Descripcion))
              .ForMember(p => p.State, q => q.MapFrom(r => r.Estado))
              .ForMember(p => p.SoccerSubCategoryId, q => q.MapFrom(r => r.FutbolSubCagoriaId))
              .ForMember(p => p.Outstanding, q => q.MapFrom(r => r.Destacado))
              .ReverseMap();
        }
    }
}
