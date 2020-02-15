using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    internal class OrderExistsException : PayException
    {
        public override PayResult ErrorCode => PayResult.OrderExists;
    }
}
