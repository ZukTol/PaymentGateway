using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Api.Entities
{
    public class Operation
    {
        public string OrderId { get; set; }
        public long AmountKop { get; set; }
        public OperationStatus Status { get; set; }
        public string CardNumber { get; set; }
    }
}
