using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    internal class InvalidCardInfoException : PayException
    {
        public override PayResult ErrorCode => PayResult.InvalidCardInfo;
    }
}
