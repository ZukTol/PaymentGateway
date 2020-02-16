using PaymentGateway.Web.Entities;

namespace PaymentGateway.Web.Services
{
    public interface ICardValidationService
    {
        void CheckCard(string cardNumber, int expiryMonth, int expiryYear);
        void CheckEnoughMoney(Card card, long amountKop);
    }
}
