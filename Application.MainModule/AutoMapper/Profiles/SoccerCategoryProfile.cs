using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class SoccerCategoryProfile : Profile
    {
        public SoccerCategoryProfile()
        {
            CreateMap<CategoriaFutbol, SoccerCategoryDto>()
              .ForMember(p => p.Name, q => q.MapFrom(r => r.Nombre))
              .ForMember(p => p.Description, q => q.MapFrom(r => r.Descripcion))
              .ForMember(p => p.State, q => q.MapFrom(r => r.Estado))
              .ForMember(p => p.SoccerSubCategorys, q => q.MapFrom(r => r.FutbolSubCagorias))
              .ReverseMap();
        }
    }
}
