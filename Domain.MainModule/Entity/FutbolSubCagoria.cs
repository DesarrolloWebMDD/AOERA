using Domain.Core.Entity;
using System.Collections.Generic;

namespace Domain.MainModule.Entity
{
    public class FutbolSubCagoria : Entity<int>
    {
        public int CategoriaFutbolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public CategoriaFutbol CategoriaFutbol { get; set; }
        public List<Ligas> Ligas { get; set; }
    }
}
