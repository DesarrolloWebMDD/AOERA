using Domain.Core.Entity;

namespace Domain.MainModule.Entity
{
    public class MaestroDetalle : Entity<int>
    {
        public string Clave { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int IdMaestro { get; set; }
        public Maestro Maestro { get; set; }
    }
}