using Domain.Core.Entity;
using System;

namespace Domain.MainModule.Entity
{
    public class Premios : Entity<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstadoPremio { get; set; }
        public decimal PuntoCanje { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool EstadoWeb { get; set; }
        public int TipoPremio { get; set; }
        public int CategoriaPremio { get; set; }
        public int Periodo { get; set; }
        public bool Estado { get; set; }
    }
}
