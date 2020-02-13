using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Exceptions
{
    internal class NotEnoughMoneyException : PayException
    {
        public override OperationResult ErrorCode => OperationResult.NotEnoughMoney;
    }
}
