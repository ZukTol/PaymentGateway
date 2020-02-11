using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions
{
    internal class InvalidCardNumberException : PayException
    {
        public override OperationResult ErrorCode => OperationResult.InvalidCardNumber;
    }
}
