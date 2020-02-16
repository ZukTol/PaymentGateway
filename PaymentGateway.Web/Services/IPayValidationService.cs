using PaymentGateway.Web.Entities;
using System;

namespace PaymentGateway.Web.Services
{
    public interface IPayValidationService
    {
        void CheckPay(Card card, long amountKop, int cvv);
        void CheckOrder(string orderId);
    }
}
