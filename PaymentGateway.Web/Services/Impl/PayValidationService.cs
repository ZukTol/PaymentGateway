using PaymentGateway.Api.Utils;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions.Pay;
using System;
using System.Linq;

namespace PaymentGateway.Web.Services.Impl
{
    public class PayValidationService : IPayValidationService
    {
        private readonly IStorageContext _storageContext;
        private readonly ICardValidationService _cardValidationService;

        public PayValidationService(IStorageContext storageContext, ICardValidationService cardValidationService)
        {
            _storageContext = storageContext;
            _cardValidationService = cardValidationService;
        }

        public void CheckOrder(string orderId)
        {
            CheckOrderIdEmpty(orderId);
            CheckOrderExists(orderId);
        }

        private void CheckOrderIdEmpty(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new OrderIdEmptyException();
            }
        }

        public void CheckPay(Card card, long amountKop, int cvv)
        {
            CheckHelper.CheckNull(card, nameof(card));

            _cardValidationService.CheckEnoughMoney(card, amountKop);
            CheckValidCvv(card, cvv);
        }

        private static void CheckValidCvv(Card card, int cvv)
        {
            if (!IsValidCvv(card, cvv))
            {
                throw new InvalidCvvException();
            }
        }

        

        private void CheckOrderExists(string orderId)
        {
            if (IsOrderExists(orderId))
            {
                throw new OrderExistsException();
            }
        }

        private bool IsOrderExists(string orderId)
        {
            return _storageContext.OperationList.Any(o => o.OrderId == orderId);
        }

        

        private static bool IsValidCvv(Card card, int cvv)
        {
            return card.Cvv == cvv;
        }

    }
}
