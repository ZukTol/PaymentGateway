using PaymentGateway.Api.Entities;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Services
{
    public interface IOperationService
    {
        void InitServerPath(string serverPath);
        Task<PayResult> Pay(string orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, long amountKop);
        OperationStatus GetStatus(string orderId);
        PayResult Refund(string orderId);
    }
}
