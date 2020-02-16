using PaymentGateway.Api.Entities;
using PaymentGateway.Api.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Services.Impl
{
    public class OperationService : IOperationService
    {
        private string _serverPath = string.Empty;

        public OperationStatus GetStatus(string orderId)
        {
            throw new NotImplementedException();
        }

        public void InitServerPath(string serverPath)
        {
            _serverPath = string.Empty;
        }

        public async Task<PayResult> Pay(string orderId, string cardNumber, int expiryMonth, int expiryYear, int cvv, long amountKop)
        {
            var request = new PayRequest
            {
                AmountKop = amountKop,
                CardNumber = cardNumber,
                Cvv = cvv,
                ExpiryMonth = expiryMonth,
                ExpiryYear = expiryYear,
                OrderId = orderId
            };
            var responce = await RestHelper.Post(_serverPath, JsonHelper.Serialize(request));
            return PayResult.Ok;
        }

        public PayResult Refund(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
