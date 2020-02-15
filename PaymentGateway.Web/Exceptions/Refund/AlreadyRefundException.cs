using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Refund
{
    public class AlreadyRefundException : RefundException
    {
        public override RefundResult ErrorCode => RefundResult.AlreadyDone;
    }
}
