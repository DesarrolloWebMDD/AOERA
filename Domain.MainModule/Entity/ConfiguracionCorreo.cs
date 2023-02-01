using Domain.Core.Entity;

namespace Domain.MainModule.Entity
{
    public class ConfiguracionCorreo : Entity<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public bool? Activo { get; set; }
    }
}
