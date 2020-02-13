using PaymentGateway.Web.Entities;
using System;

namespace PaymentGateway.Web.Services
{
    interface IOperationValidationService
    {
        void CheckPay(Card card, long amountKop, int cvv);
        void CheckOrder(Guid orderId);
    }
}
