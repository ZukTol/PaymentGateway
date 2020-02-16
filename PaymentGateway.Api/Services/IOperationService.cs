using PaymentGateway.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Services
{
    public interface IOperationService
    {
        void InitServerPath(string serverPath);
        Task<PayResult> Pay(string orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, long amountKop);
        Task<OperationStatus> GetStatus(string orderId);
        Task<RefundResult> Refund(string orderId);
        Task<List<Operation>> GetOperationList();
    }
}
