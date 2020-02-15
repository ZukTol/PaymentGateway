using System;

namespace PaymentGateway.Web.Services
{
    public interface IRefundValidationService
    {
        void CheckOrder(Guid orderId);
    }
}
