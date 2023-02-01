using Domain.Core.Entity;
using System;

namespace Domain.MainModule.Entity
{
    public class PremiosAuditoria : Entity<int>
    {
        public int UsuarioId { get; set; }
        public int PremioId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int PuntosUsarioId { get; set; }
        public bool Estado { get; set; }
        public Premios Premio { get; set; }
        public Usuario Usuario { get; set; }
    }
}
