using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    public class OrderExistsException : PayException
    {
        public override PayResult ErrorCode => PayResult.OrderExists;
    }
}
