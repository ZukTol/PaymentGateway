using PaymentGateway.Api.Entities;
using System;

namespace PaymentGateway.Api.Services
{
    public interface IOperationService
    {
        OperationResult Pay(Guid orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, string cardholderName, long amountKop);
        OperationStatus GetStatus(Guid orderId);
        OperationResult Refund(Guid orderId);
    }
}
