using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    public class NotEnoughMoneyException : PayException
    {
        public override PayResult ErrorCode => PayResult.NotEnoughMoney;
    }
}
