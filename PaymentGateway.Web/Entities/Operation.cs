using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Web.Entities
{
    public class Operation
    {
        public Guid OrderId { get; set; }
        public long AmountKop { get; set; }
        public OperationStatus Status { get; set; }
    }
}
