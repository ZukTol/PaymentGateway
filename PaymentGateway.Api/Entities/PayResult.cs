namespace PaymentGateway.Api.Entities
{
    public enum PayResult
    {
        Ok = 0,
        InvalidCardInfo = 1,
        OrderExists = 2,
        NotEnoughMoney = 3,
        WrongCvv = 4
    }
}
