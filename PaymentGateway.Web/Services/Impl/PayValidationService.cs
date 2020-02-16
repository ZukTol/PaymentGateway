using PaymentGateway.Api.Utils;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions.Pay;
using System;
using System.Linq;

namespace PaymentGateway.Web.Services.Impl
{
    internal class PayValidationService : IPayValidationService
    {
        private readonly IStorageContext _storageContext;

        public PayValidationService(IStorageContext storageContext)
        {
            _storageContext = storageContext;
        }

        public void CheckOrder(string orderId)
        {
            CheckOrderExists(orderId);
        }

        public void CheckPay(Card card, long amountKop, int cvv)
        {
            CheckHelper.CheckNull(card, nameof(card));

            CheckEnoughMoney(card, amountKop);
            CheckValidCvv(card, cvv);
        }

        private static void CheckValidCvv(Card card, int cvv)
        {
            if (!IsValidCvv(card, cvv))
            {
                throw new WrongCvvException();
            }
        }

        private static void CheckEnoughMoney(Card card, long amountKop)
        {
            if (!IsEnoughMoney(card, amountKop))
            {
                throw new NotEnoughMoneyException();
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

        private static bool IsEnoughMoney(Card card, long amountKop)
        {
            return card.IsUnlimited || card.Balance > amountKop;
        }

        private static bool IsValidCvv(Card card, int cvv)
        {
            return card.Cvv == cvv;
        }

    }
}
