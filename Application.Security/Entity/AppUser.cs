using System;
using System.Collections.Generic;
using System.Security.Claims;
using Application.Security.Enum;

namespace Application.Security.Entity
{
    public class AppUser
    {
        public AppUser() { }

        public AppUser(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                Id = Convert.ToInt32(claimsPrincipal.FindFirst(ClaimType.Id)?.Value);
                //CurrentRolId = Convert.ToInt32(claimsPrincipal.FindFirst(ClaimType.RolId)?.Value);
                Nombre = claimsPrincipal.FindFirst(ClaimType.Name)?.Value;
                UserName = claimsPrincipal.FindFirst(ClaimType.Username)?.Value;
                Email = claimsPrincipal.FindFirst(ClaimType.Email)?.Value;
                //Platform = claimsPrincipal.FindFirst(ClaimType.Platform)?.Value;
                //Company = claimsPrincipal.FindFirst(ClaimType.Company)?.Value;
            }
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
        public string ImagenOriginal { get; set; }
        public string KeyImagen { get; set; }
    }
}