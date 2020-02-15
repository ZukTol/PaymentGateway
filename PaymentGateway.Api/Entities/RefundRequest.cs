using System;

namespace PaymentGateway.Api.Entities
{
    public class RefundRequest
    {
        public Guid OrderId { get; set; }
    }
}
