using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Utils;
using System;
using System.Linq;

namespace PaymentGateway.Web.Services.Impl
{
    public class CardService : ICardService
    {
        private readonly ICardValidationService _cardValidationService;
        private readonly IStorageContext _storageContext;

        public CardService(ICardValidationService cardValidationService, IStorageContext storageContext)
        {
            _cardValidationService = cardValidationService;
            _storageContext = storageContext;
        }

        public void Decrease(Guid cardId, long amountKop)
        {
            var card = _storageContext.CardList.First(c => c.Id == cardId);
            _cardValidationService.CheckEnoughMoney(card, amountKop);
            card.Balance -= amountKop;
        }

        public Card GetCard(string cardNumber, int expiryMonth, int expiryYear, string cardholderName)
        {
            _cardValidationService.CheckCard(cardNumber, expiryMonth, expiryYear);
            return _storageContext.CardList.FirstOrDefault(c => 
                string.Equals(c.Number, cardNumber.RemoveSpace(), StringComparison.OrdinalIgnoreCase) 
                && c.ExpiryMonth == expiryMonth 
                && c.ExpireYear == expiryYear);
            
        }

        public void Increase(Guid cardId, long amountKop)
        {
            var card = _storageContext.CardList.First(c => c.Id == cardId);
            card.Balance += amountKop;
        }
    }
}
