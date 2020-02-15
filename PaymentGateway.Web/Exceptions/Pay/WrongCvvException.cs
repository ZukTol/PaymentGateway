using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    internal class WrongCvvException : PayException
    {
        public override PayResult ErrorCode => PayResult.WrongCvv;
    }
}
