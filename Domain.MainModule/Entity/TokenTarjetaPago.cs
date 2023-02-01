using Domain.Core.Entity;
using System;

namespace Domain.MainModule.Entity
{
    public class TokenTarjetaPago : Entity<int>
    {
        public string IdUser { get; set; }
        public string Token { get; set; }
        public string PanTarjeta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EstadoTarjeta { get; set; }
    }
}
