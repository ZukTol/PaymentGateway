using System;

namespace PaymentGateway.Api.Entities
{
    public class PayRequest
    {
        public Guid OrderId { get; set; } 
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int Cvv { get; set; }
        public string CardholderName { get; set; }
        public long AmountKop { get; set; }
    }
}
