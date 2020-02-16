namespace PaymentGateway.Api.Entities
{
    public enum PayResult
    {
        Ok = 0,
        InvalidCardNumber = 1,
        OrderExists = 2,
        NotEnoughMoney = 3,
        InvalidCvv = 4,
        InvalidExpiryDate = 5,
        OrderIdEmpty = 6
    }
}
