using PaymentGateway.Api.Entities;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Utils;
using System;

namespace PaymentGateway.Web.Services.Impl
{
    internal class OperationService : IOperationService
    {
        private readonly ICardService _cardService;
        private readonly IStorageContext _storageContext;
        private readonly IOperationValidationService _operationValidationService;

        public OperationService(ICardService cardService, IStorageContext storageContext, IOperationValidationService operationValidationService)
        {
            _cardService = cardService;
            _storageContext = storageContext;
            _operationValidationService = operationValidationService;
        }

        public OperationResult Pay(Guid orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, string cardholderName, long amountKop)
        {
            var card = _cardService.GetCard(cardNumber, expiryMonth, expiryYear, cardNumber);
            CheckPayOperation(card, orderId, amountKop, cvv);
            AddPayOperation(orderId, card, amountKop);
            _cardService.Decrease(card.Id, amountKop);
            return OperationResult.Ok;
        }

        private void CheckPayOperation(Card card, Guid orderId, long amountKop, int cvv)
        {
            CheckHelper.CheckNull(card, nameof(card));

            _operationValidationService.CheckOrder(orderId);
            _operationValidationService.CheckPay(card, amountKop, cvv);
        }

        private void AddPayOperation(Guid orderId, Card card, long amountKop)
        {
            var operation = CreatePayOperation(orderId, card, amountKop);
            _storageContext.OperationList.Add(operation);
        }

        private Operation CreatePayOperation(Guid orderId, Card card, long amountKop)
        {
            return new Operation()
            {
                AmountKop = amountKop,
                Card = card,
                OrderId = orderId,
                Status = OperationStatus.Done
            };
        }
    }
}
