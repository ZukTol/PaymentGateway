using System;

namespace PaymentGateway.Api.Entities
{
    public class PayRequest
    {
        public string OrderId { get; set; } 
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int Cvv { get; set; }
        public long AmountKop { get; set; }
    }
}
