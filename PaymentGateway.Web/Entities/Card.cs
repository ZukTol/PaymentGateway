using System;

namespace PaymentGateway.Web.Entities
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpireYear { get; set; }
        public int Cvv { get; set; }
        public long Balance { get; set; }
        public bool IsUnlimited { get; set; } = false;
    }
}
