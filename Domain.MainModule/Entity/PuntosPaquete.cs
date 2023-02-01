using Domain.Core.Entity;

namespace Domain.MainModule.Entity
{
    public class PuntosPaquete : Entity<int>
    {
        public decimal PuntosOferta { get; set; }
        public decimal Valor { get; set; }
        public decimal PuntosAcumulados { get; set; }
        public bool Estado { get; set; }
    }
}
