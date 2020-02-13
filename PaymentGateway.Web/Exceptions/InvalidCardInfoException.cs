using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions
{
    internal class InvalidCardInfoException : PayException
    {
        public override OperationResult ErrorCode => OperationResult.InvalidCardInfo;
    }
}
