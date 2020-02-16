using PaymentGateway.Api.Entities;
using PaymentGateway.Api.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Services.Impl
{
    public class OperationService : IOperationService
    {
        private string _serverPath = string.Empty;

        public async Task<OperationStatus> GetStatus(string orderId)
        {
            var serverAddress = string.Concat(_serverPath, Constants.Ctrl.Slash, Constants.Service.GetStatus , Constants.Ctrl.Slash, orderId);
            var response = await RestHelper.Get(serverAddress);
            return ParseEnumResult<OperationStatus>(response);
        }

        public void InitServerPath(string serverPath)
        {
            _serverPath = serverPath;
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
            return ParseEnumResult<PayResult>(responce);
        }

        public async Task<RefundResult> Refund(string orderId)
        {
            var serverAddress = string.Concat(_serverPath, Constants.Ctrl.Slash, Constants.Service.Refund);
            var request = new RefundRequest { OrderId = orderId };
            var responce = await RestHelper.Post(serverAddress, JsonHelper.Serialize(request));
            return ParseEnumResult<RefundResult>(responce);
        }

        private static T ParseEnumResult<T>(string responce) where T : Enum
        {
            CheckHelper.CheckNull(responce, nameof(responce));

            var result = (T)Enum.Parse(typeof(T), responce);
            return result;
        }

        public async Task<List<Operation>> GetOperationList()
        {
            var responce = await RestHelper.Get(_serverPath);
            return JsonHelper.Deserialize<List<Operation>>(responce);
        }
    }
}
