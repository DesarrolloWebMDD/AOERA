using System.Collections.Generic;
using Domain.Core.Entity;

namespace Domain.MainModule.Entity
{
    public class Maestro : Entity<int>
    {
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public List<MaestroDetalle> MaestroDetalleLista { get; set; }
    }
}