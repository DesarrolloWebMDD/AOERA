using Domain.Core.Entity;
using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entity
{
    public class Usuario : Entity<int>
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Clave { get; set; }
        public string ImagenOriginal { get; set; }
        public string KeyImagen { get; set; }
        public string CodigoReferencia { get; set; }
        public string CodigoInvitacion { get; set; }
        public bool Estado { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string CiudadRecidencia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public List<Membresia> Membresias { get; set; }
        public UsuarioPunto UsuarioPunto { get; set; }
    }
}