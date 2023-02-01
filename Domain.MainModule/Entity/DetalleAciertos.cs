using Domain.Core.Entity;

namespace Domain.MainModule.Entity
{
    public class DetalleAciertos : Entity<int>
    {
        public int? AciertoId { get; set; }
        public int? DeporteId { get; set; }
        public int TipoApuestaId { get; set; }
        public string TipoApuestaTexto { get; set; }
        public decimal PuntoGanar { get; set; }
        public string EquiposRivales { get; set; }
        public bool? ResultadoFinal { get; set; }
        public bool? EstadoProceso { get; set; }
        public bool? Estado { get; set; }
        public Aciertos Acierto { get; set; }
        public Deportes Deporte { get; set; }
    }
}
