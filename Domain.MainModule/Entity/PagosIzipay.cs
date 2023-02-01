using Domain.Core.Entity;
using System;

namespace Domain.MainModule.Entity
{
    public class PagosIzipay : Entity<int>
    {
        public string shopId { get; set; }
        public string orderCycle { get; set; }
        public string orderStatus { get; set; }
        public DateTime serverDate { get; set; }
        public decimal orderTotalAmount { get; set; }
        public string orderCurrency { get; set; }
        public string orderId { get; set; }
        public string address { get; set; }
        public string cellPhoneNumber { get; set; }
        public string uuid { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string paymentMethodType { get; set; }
        public string paymentMethodToken { get; set; }
        public string operationType { get; set; }
        public string pan { get; set; }
        public int expiryMonth { get; set; }
        public int expiryYear { get; set; }
        public string country { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int EstadoRegistro { get; set; }
    }
}
