using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class SporHitsProfile : Profile
    {
        public SporHitsProfile()
        {
            CreateMap<Aciertos, SportHitsDto>()
             .ForMember(p => p.UserId, q => q.MapFrom(r => r.UserId))
             .ForMember(p => p.CreateDate, q => q.MapFrom(r => r.FechaCreado))
             .ForMember(p => p.HitType, q => q.MapFrom(r => r.TipoAcierto))
             .ForMember(p => p.PointsHit, q => q.MapFrom(r => r.PuntoApostado))
             .ForMember(p => p.PointsEarn, q => q.MapFrom(r => r.PuntoGanar))
             .ForMember(p => p.HitsState, q => q.MapFrom(r => r.EstadoAcierto))
             .ForMember(p => p.FinalyResult, q => q.MapFrom(r => r.ResultadoFinal))
             .ForMember(p => p.State, q => q.MapFrom(r => r.Estado))
             .ForMember(p => p.Code, q => q.MapFrom(r => r.Codigo))
             .ForMember(p => p.SportHitsDetails, q => q.MapFrom(r => r.DetalleAciertos))
             .ReverseMap();

            CreateMap<DetalleAciertos, SportHitsDetailDto>()
           .ForMember(p => p.HitId, q => q.MapFrom(r => r.AciertoId))
           .ForMember(p => p.MatchId, q => q.MapFrom(r => r.DeporteId))
           .ForMember(p => p.BetTypeId, q => q.MapFrom(r => r.TipoApuestaId))
           .ForMember(p => p.BetTypeResult, q => q.MapFrom(r => r.EquiposRivales))
           .ForMember(p => p.PointGame, q => q.MapFrom(r => r.PuntoGanar))
           .ForMember(p => p.PlayGameText, q => q.MapFrom(r => r.TipoApuestaTexto))
           .ForMember(p => p.FinalyResult, q => q.MapFrom(r => r.ResultadoFinal))
           .ForMember(p => p.State, q => q.MapFrom(r => r.Estado));

            CreateMap<SportHitsDetailDto, DetalleAciertos>()
         .ForMember(p => p.AciertoId, q => q.MapFrom(r => r.HitId))
         .ForMember(p => p.DeporteId, q => q.MapFrom(r => r.MatchId))
         .ForMember(p => p.TipoApuestaId, q => q.MapFrom(r => r.BetTypeId))
         .ForMember(p => p.EquiposRivales, q => q.MapFrom(r => r.BetTypeResult))
         .ForMember(p => p.PuntoGanar, q => q.MapFrom(r => r.PointGame))
         .ForMember(p => p.TipoApuestaTexto, q => q.MapFrom(r => r.PlayGameText))
         .ForMember(p => p.ResultadoFinal, q => q.MapFrom(r => r.FinalyResult))
         .ForMember(p => p.Estado, q => q.MapFrom(r => true));

        }
    }
}
