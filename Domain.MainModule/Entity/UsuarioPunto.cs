using Domain.Core.Entity;

namespace Domain.MainModule.Entity
{
    public class UsuarioPunto:Entity<int>
    {
        public int Periodo { get; set; }
        public int UsuarioId { get; set; }
        public decimal? PuntosMembresia { get; set; }
        public decimal? PuntosRecarga { get; set; } = 0;
        public decimal? PuntosPerdidos { get; set; }
        public decimal? PuntosAcumulados { get; set; }
        public bool Estado { get; set; }
        public Usuario Usuario { get; set; }
    }
}
