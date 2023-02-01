using Domain.Core.Entity;
using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entity
{
    public class Aciertos : Entity<int>
    {
        public int UserId { get; set; }
        public DateTime FechaCreado { get; set; }
        public int TipoAcierto { get; set; }
        public int PuntoApostado { get; set; }
        public decimal PuntoGanar { get; set; }
        public int? EstadoAcierto { get; set; }
        public bool? ResultadoFinal { get; set; }
        public bool? Estado { get; set; }
        public string Codigo { get; set; }
        public List<DetalleAciertos> DetalleAciertos { get; set; }
    }
}
