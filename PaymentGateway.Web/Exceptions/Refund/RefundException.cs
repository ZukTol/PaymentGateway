using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Web.Exceptions.Refund
{
    public abstract class RefundException : Exception
    {
        public abstract RefundResult ErrorCode { get; }
    }
}
