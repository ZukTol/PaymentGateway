using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    public class InvalidCvvException : PayException
    {
        public override PayResult ErrorCode => PayResult.InvalidCvv;
    }
}
