using Domain.Core.Entity;

namespace Domain.MainModule.Entity
{
    public class DeporteResultados : Entity<int>
    {
        public int DeporteId { get; set; }
        public string TextoTipo { get; set; }
        public int? ValorExtra { get; set; }
        public decimal PuntoResultado { get; set; }
        public int TipoResultado { get; set; }
        public bool Resultado { get; set; }
        public bool Estado { get; set; }
        public Deportes Deporte { get; set; }
    }
}
