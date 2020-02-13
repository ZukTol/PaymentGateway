using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions;
using PaymentGateway.Web.Utils;
using System;
using System.Linq;

namespace PaymentGateway.Web.Services.Impl
{
    internal class OperationValidationService : IOperationValidationService
    {
        private readonly IStorageContext _storageContext;

        public OperationValidationService(IStorageContext storageContext)
        {
            _storageContext = storageContext;
        }

        public void CheckOrder(Guid orderId)
        {
            if (IsOrderExists(orderId))
            {
                throw new OrderExistsException();
            }
        }

        public void CheckPay(Card card, long amountKop, int cvv)
        {
            CheckHelper.CheckNull(card, nameof(card));

            if(!IsEnoughMoney(card, amountKop))
            {
                throw new NotEnoughMoneyException();
            }

            if(!IsValidCvv(card, cvv))
            {
                throw new WrongCvvException();
            }
        }

        private bool IsOrderExists(Guid orderId)
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
