using System;

namespace Domain.Core.Interface
{
    public interface IAuditEntity
    {
        int? UsuarioCreacion { get; set; }
        int? UsuarioModificacion { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime? FechaModificacion { get; set; }
    }
}