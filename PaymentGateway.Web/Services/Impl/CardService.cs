using System;

namespace PaymentGateway.Web.Services.Impl
{
    public class CardService : ICardService
    {
        public void Decrease(Guid cardId, long amountKop)
        {
            throw new NotImplementedException();
        }

        public Guid GetCard(string cardNumber, int expiryMonth, int expiryYear, string cardholderName)
        {
            throw new NotImplementedException();
        }

        public void Increase(Guid cardId, long amountKop)
        {
            throw new NotImplementedException();
        }
    }
}
