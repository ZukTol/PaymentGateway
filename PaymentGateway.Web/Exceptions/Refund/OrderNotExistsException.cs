using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Refund
{
    public class OrderNotExistsException : RefundException
    {
        public override RefundResult ErrorCode => RefundResult.OrderNotFound;
    }
}
