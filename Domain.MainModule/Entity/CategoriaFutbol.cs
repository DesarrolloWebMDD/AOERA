using Domain.Core.Entity;
using System.Collections.Generic;

namespace Domain.MainModule.Entity
{
    public class CategoriaFutbol : Entity<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public  bool Estado { get; set; }
        public List<FutbolSubCagoria> FutbolSubCagorias { get; set; }
    }
}
