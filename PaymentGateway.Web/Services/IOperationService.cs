using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Web.Services
{
    public interface IOperationService
    {
        PayResult Pay(string orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, string cardholderName, long amountKop);
        OperationStatus GetStatus(string orderId);
        RefundResult Refund(string orderId);
    }
}
