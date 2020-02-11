using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Web.Exceptions
{
    internal abstract class PayException : Exception
    {
        public abstract OperationResult ErrorCode { get; }
    }
}
