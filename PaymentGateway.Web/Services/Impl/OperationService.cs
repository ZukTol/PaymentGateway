using PaymentGateway.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Web.Services.Impl
{
    public class OperationService : IOperationService
    {
        private readonly ICardService _cardService;
        private readonly IStorageContext _storageContext;

        public OperationService(ICardService cardService, IStorageContext storageContext)
        {
            _cardService = cardService;
            _storageContext = storageContext;

        }
        public OperationResult Pay(Guid orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, string cardholderName, long amountKop)
        {
            var cardId = _cardService.GetCard(cardNumber, expiryMonth, expiryYear, cardNumber);
            throw new NotImplementedException();
        }


    }
}
