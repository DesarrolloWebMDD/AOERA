using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class SportsProfile : Profile
    {
        public SportsProfile()
        {
            CreateMap<Deportes, SportsDto>()
              .ForMember(x => x.Hour, m => m.MapFrom(d => d.Hora))
              .ForMember(x => x.DateHour, m => m.MapFrom(d => d.FechaHora))
              .ForMember(x => x.DeportText, m => m.MapFrom(d => d.EquiposReviales))
              .ForMember(x => x.TeamA, m => m.MapFrom(d => d.EquipoA))
              .ForMember(x => x.TeamB, m => m.MapFrom(d => d.EquipoB))
              .ForMember(x => x.PointA, m => m.MapFrom(d => d.PuntoA))
              .ForMember(x => x.PointB, m => m.MapFrom(d => d.PuntoB))
              .ForMember(x => x.TieText, m => m.MapFrom(d => d.EmpateTexto))
              .ForMember(x => x.PointTie, m => m.MapFrom(d => d.EmpatePunto))
              .ForMember(x => x.Goal1Text, m => m.MapFrom(d => d.Gol1Text))
              .ForMember(x => x.PointGoal1, m => m.MapFrom(d => d.PuntoGol1))
              .ForMember(x => x.Goal2Text, m => m.MapFrom(d => d.Gol2Text))
              .ForMember(x => x.PointGoal2, m => m.MapFrom(d => d.PuntoGol2))
              .ForMember(x => x.Goal3Text, m => m.MapFrom(d => d.Gol3Text))
              .ForMember(x => x.PointGoal3, m => m.MapFrom(d => d.PuntoGol3))
              .ForMember(x => x.Goal4Text, m => m.MapFrom(d => d.Gol4Text))
              .ForMember(x => x.PointGoal4, m => m.MapFrom(d => d.PuntoGol4))
              .ForMember(x => x.Goal_1Text, m => m.MapFrom(d => d.Gol_1Text))
              .ForMember(x => x.PointGoal_1, m => m.MapFrom(d => d.PuntoGol_1))
              .ForMember(x => x.Goal_2Text, m => m.MapFrom(d => d.Gol_2Text))
              .ForMember(x => x.PointGoal_2, m => m.MapFrom(d => d.PuntoGol_2))
              .ForMember(x => x.Goal_3Text, m => m.MapFrom(d => d.Gol_3Text))
              .ForMember(x => x.PointGoal_3, m => m.MapFrom(d => d.PuntoGol_3))
              .ForMember(x => x.Goal_4Text, m => m.MapFrom(d => d.Gol_4Text))
              .ForMember(x => x.PointGoal_4, m => m.MapFrom(d => d.PuntoGol_4))
              .ForMember(x => x.TeamLE, m => m.MapFrom(d => d.LocalEmpateTexto))
              .ForMember(x => x.PointLE, m => m.MapFrom(d => d.LocalEmpatePunto))
              .ForMember(x => x.TeamEV, m => m.MapFrom(d => d.EmpateVisitaTexto))
              .ForMember(x => x.PointEV, m => m.MapFrom(d => d.EmpateVisitaPunto))
              .ForMember(x => x.GoalSi, m => m.MapFrom(d => d.GolColSiTexto))
              .ForMember(x => x.PointSI, m => m.MapFrom(d => d.GolColSiPunto))
              .ForMember(x => x.GoalNo, m => m.MapFrom(d => d.GolColNoTexto))
              .ForMember(x => x.PointNO, m => m.MapFrom(d => d.GolColNoPunto))
              .ForMember(x => x.LigueId, m => m.MapFrom(d => d.LigaId))
              .ForMember(x => x.StateSport, m => m.MapFrom(d => d.EstadoJuego))
              .ForMember(x => x.SportResults, m => m.MapFrom(d => d.DeporteResultados))
              .ReverseMap();

            CreateMap<Deportes, SportsListDto>()
            .ForMember(x => x.Hour, m => m.MapFrom(d => d.Hora))
            .ForMember(x => x.DateHour, m => m.MapFrom(d => d.FechaHora))
            .ForMember(x => x.DeportText, m => m.MapFrom(d => d.EquiposReviales))
            .ForMember(x => x.StateSport, m => m.MapFrom(d => d.EstadoJuego))
            .ForMember(x => x.State, m => m.MapFrom(d => d.Estado))
            .ForMember(x => x.Ligue, m => m.MapFrom(d => d.Liga))
            .ReverseMap();
        }
    }
}
