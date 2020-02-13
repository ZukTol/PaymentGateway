using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions
{
    internal class OrderExistsException : PayException
    {
        public override OperationResult ErrorCode => OperationResult.OrderExists;
    }
}
