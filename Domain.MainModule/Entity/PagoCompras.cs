using Domain.Core.Entity;
using System;

namespace Domain.MainModule.Entity
{
    public class PagoCompras : Entity<int>
    {
        public string IdTienda { get; set; }
        public string NumTransaccion { get; set; }
        public string NumAutorizacion { get; set; }
        public string NumOrden { get; set; }
        public string RefUnicaTransaccion { get; set; }
        public string NumTransaccionExterna { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal TotalPago { get; set; }
        public string Moneda { get; set; }
        public string CanalPago { get; set; }
        public string TipoTarjeta { get; set; }
        public string PanTarjeta { get; set; }
        public string IdUser { get; set; }
        public string EstadoPago { get; set; }
    }
}
