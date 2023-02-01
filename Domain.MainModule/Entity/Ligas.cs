using Domain.Core.Entity;
using System.Collections.Generic;

namespace Domain.MainModule.Entity
{
    public class Ligas : Entity<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public int? FutbolSubCagoriaId { get; set; }
        public bool? Destacado { get; set; }
        public FutbolSubCagoria FutbolSubCagoria { get; set; }
        public List<Deportes> Deportes { get; set; }
    }
}
