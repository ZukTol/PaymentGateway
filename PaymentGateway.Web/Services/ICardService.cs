using PaymentGateway.Web.Entities;
using System;

namespace PaymentGateway.Web.Services
{
    public interface ICardService
    {
        Card GetCard(string cardNumber, int expiryMonth, int expiryYear, string cardholderName);
        void Increase(Guid cardId, long amountKop);
        void Decrease(Guid cardId, long amountKop);
    }
}
