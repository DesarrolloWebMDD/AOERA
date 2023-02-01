using Domain.Core.Interface;
using System;

namespace Domain.Core.Entity
{
    public class AuditEntity<T> : Entity<T>, IAuditEntity
    {
        public int? UsuarioCreacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}