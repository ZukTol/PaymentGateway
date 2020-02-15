using PaymentGateway.Api.Entities;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Utils;
using System;
using System.Linq;

namespace PaymentGateway.Web.Services.Impl
{
    internal class OperationService : IOperationService
    {
        private readonly ICardService _cardService;
        private readonly IStorageContext _storageContext;
        private readonly IPayValidationService _operationValidationService;
        private readonly IRefundValidationService _refundValidationService;

        public OperationService(ICardService cardService, IStorageContext storageContext, IPayValidationService operationValidationService, IRefundValidationService refundValidationService)
        {
            _cardService = cardService;
            _storageContext = storageContext;
            _operationValidationService = operationValidationService;
            _refundValidationService = refundValidationService;
        }

        public PayResult Pay(Guid orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, string cardholderName, long amountKop)
        {
            var card = _cardService.GetCard(cardNumber, expiryMonth, expiryYear, cardNumber);
            CheckPayOperation(card, orderId, amountKop, cvv);
            AddPayOperation(orderId, card, amountKop);
            DecreaseCardBalance(card.Id, amountKop);
            return PayResult.Ok;
        }

        public OperationStatus GetStatus(Guid orderId)
        {
            var operation = _storageContext.OperationList.FirstOrDefault(o => o.OrderId == orderId);
            return operation?.Status ?? OperationStatus.NotFound;
        }

        public RefundResult Refund(Guid orderId)
        {
            _refundValidationService.CheckOrder(orderId);
            SetOrderStatusRefund(orderId);
            RestoreCardBalance(orderId);
            return RefundResult.Ok;
        }

        private void DecreaseCardBalance(Guid cardId, long amountKop)
        {
            _cardService.Decrease(cardId, amountKop);
        }

        private void RestoreCardBalance(Guid orderId)
        {
            var order = GetOperationById(orderId);
            _cardService.Decrease(order.Card.Id, order.AmountKop);
        }

        private void SetOrderStatusRefund(Guid orderId)
        {
            var order = GetOperationById(orderId);
            order.Status = OperationStatus.Refund;
        }

        private Operation GetOperationById(Guid orderId)
        {
            return _storageContext.OperationList.First(o => o.OrderId == orderId);
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
