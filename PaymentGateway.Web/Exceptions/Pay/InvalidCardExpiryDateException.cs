using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    public class InvalidCardExpiryDateException : PayException
    {
        public override PayResult ErrorCode => PayResult.InvalidExpiryDate;
    }
}
