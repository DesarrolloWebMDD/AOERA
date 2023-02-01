using Domain.Core.Entity;
using System;

namespace Domain.MainModule.Entity
{
    public class Membresia : Entity<int>
    {
        public int UsuarioId { get; set; }
        public DateTime FechaActivacion { get; set; }
        public DateTime FechaFinMembresia { get; set; }
        public bool EstadoMembresia { get; set; }
        public decimal? MontoPagado { get; set; }
        public int MedioPago { get; set; }
        public bool Estado { get; set; }
        public Usuario Usuario { get; set; }
    }
}
