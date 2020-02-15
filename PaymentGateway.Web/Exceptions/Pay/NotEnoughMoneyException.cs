using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions.Pay
{
    internal class NotEnoughMoneyException : PayException
    {
        public override PayResult ErrorCode => PayResult.NotEnoughMoney;
    }
}
