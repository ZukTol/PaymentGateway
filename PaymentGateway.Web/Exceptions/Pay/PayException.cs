using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Web.Exceptions.Pay
{
    public abstract class PayException : Exception
    {
        public abstract PayResult ErrorCode { get; }
    }
}
