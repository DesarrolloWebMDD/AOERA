using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class UserPointProfile : Profile
    {
        public UserPointProfile()
        {
            CreateMap<UsuarioPunto, UserPointDto>()
                .ForMember(p => p.Amount, q => q.MapFrom(r => r.Periodo))
                .ForMember(p => p.UserId, q => q.MapFrom(r => r.UsuarioId))
                .ForMember(p => p.MembershipPoint, q => q.MapFrom(r => r.PuntosMembresia))
                .ForMember(p => p.ChargingPoints, q => q.MapFrom(r => r.PuntosRecarga))
                .ForMember(p => p.MissingPoints, q => q.MapFrom(r => r.PuntosPerdidos))
                .ForMember(p => p.AccumulatedPoints, q => q.MapFrom(r => r.PuntosAcumulados))
                //.ForMember(p => p.PointAll, q => q.MapFrom(r => (r.PuntosMembresia == null ? 0 : r.PuntosMembresia) + (r.PuntosRecarga)))
                .ForMember(p => p.State, q => q.MapFrom(r => r.Estado));



            //CreateMap<UserPointDto, UsuarioPunto>()
            //   .ForMember(p => p.Amount, q => q.MapFrom(r => r.Periodo))
            //   .ForMember(p => p.UserId, q => q.MapFrom(r => r.UsuarioId))
            //   .ForMember(p => p.MembershipPoint, q => q.MapFrom(r => r.PuntosMembresia))
            //   .ForMember(p => p.ChargingPoints, q => q.MapFrom(r => r.PuntosRecarga))
            //   .ForMember(p => p.MissingPoints, q => q.MapFrom(r => r.PuntosPerdidos))
            //   .ForMember(p => p.AccumulatedPoints, q => q.MapFrom(r => r.PuntosAcumulados))
            //   //.ForMember(p => p.PointAll, q => q.MapFrom(r => r.PuntosMembresia + r.PuntosRecarga))
            //   .ForMember(p => p.State, q => q.MapFrom(r => r.Estado));
        }
    }
}
