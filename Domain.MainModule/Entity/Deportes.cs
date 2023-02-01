using Domain.Core.Entity;
using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entity
{
    public class Deportes : Entity<int>
    {
        public string Hora { get; set; }
        public DateTime FechaHora { get; set; }
        public string EquiposReviales { get; set; }
        public string EquipoA { get; set; }
        public string EquipoB { get; set; }
        public decimal? PuntoA { get; set; }
        public decimal? PuntoB { get; set; }
        public string EmpateTexto { get; set; }
        public decimal? EmpatePunto { get; set; }
        public string Gol1Text { get; set; }
        public decimal? PuntoGol1 { get; set; }
        public string Gol2Text { get; set; }
        public decimal? PuntoGol2 { get; set; }
        public string Gol3Text { get; set; }
        public decimal? PuntoGol3 { get; set; }
        public string Gol4Text { get; set; }
        public decimal? PuntoGol4 { get; set; }
        public string Gol_1Text { get; set; }
        public decimal PuntoGol_1 { get; set; }
        public string Gol_2Text { get; set; }
        public decimal PuntoGol_2 { get; set; }
        public string Gol_3Text { get; set; }
        public decimal PuntoGol_3 { get; set; }
        public string Gol_4Text { get; set; }
        public decimal PuntoGol_4 { get; set; }
        public string LocalEmpateTexto { get; set; }
        public decimal LocalEmpatePunto { get; set; }
        public string EmpateVisitaTexto { get; set; }
        public decimal EmpateVisitaPunto { get; set; }
        public string GolColSiTexto { get; set; }
        public decimal GolColSiPunto { get; set; }
        public string GolColNoTexto { get; set; }
        public decimal GolColNoPunto { get; set; }
        public int EstadoJuego { get; set; }
        public decimal TotalCorners { get; set; }
        public decimal TotalTarjetas { get; set; }
        public decimal TotalGoles { get; set; }
        public bool Estado { get; set; }
        public int? LigaId { get; set; }
        public Ligas Liga { get; set; }
        public List<DeporteResultados> DeporteResultados { get; set; }
    }
}
