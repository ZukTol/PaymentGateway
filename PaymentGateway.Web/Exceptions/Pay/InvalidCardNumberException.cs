using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    public class InvalidCardNumberException : PayException
    {
        public override PayResult ErrorCode => PayResult.InvalidCardNumber;
    }
}
