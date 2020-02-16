using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Web.Services
{
    public interface IOperationService
    {
        PayResult Pay(string orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, long amountKop);
        OperationStatus GetStatus(string orderId);
        RefundResult Refund(string orderId);
    }
}
