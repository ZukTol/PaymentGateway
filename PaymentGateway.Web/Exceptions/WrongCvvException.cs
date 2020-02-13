using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions
{
    internal class WrongCvvException : PayException
    {
        public override OperationResult ErrorCode => OperationResult.WrongCvv;
    }
}
