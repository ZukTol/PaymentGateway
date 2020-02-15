using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Web.Exceptions.Pay
{
    internal abstract class PayException : Exception
    {
        public abstract PayResult ErrorCode { get; }
    }
}
