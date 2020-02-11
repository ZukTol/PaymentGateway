using PaymentGateway.Web.Entities;

namespace PaymentGateway.Web.Services
{
    public interface ICardValidationService
    {
        void CheckCard(Card card);
    }
}
