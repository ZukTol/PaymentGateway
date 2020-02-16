using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Web.Entities
{
    public class Operation
    {
        public string OrderId { get; set; }
        public long AmountKop { get; set; }
        public OperationStatus Status { get; set; }
        public Card Card { get; set; }
    }
}
