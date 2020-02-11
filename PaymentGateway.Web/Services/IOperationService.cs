using PaymentGateway.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Web.Services
{
    public interface IOperationService
    {
        OperationResult Pay(Guid orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, string cardholderName, long amountKop);
    }
}
