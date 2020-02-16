using PaymentGateway.Api.Entities;
using PaymentGateway.Api.Services;
using PaymentGateway.Client.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services.Impl
{
    internal class RefundMenuService : IRefundMenuService
    {
        private readonly IOperationService _operationService;

        public RefundMenuService(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public async Task RunMenu()
        {

            var orderId = ConsoleHelper.GetTextInput(TextConstants.Refund.Menu.EnterOrderId); ;
            
            var result = await _operationService.Refund(orderId);

            PrintOperationResult(result);
        }

        private void PrintOperationResult(RefundResult result)
        {
            string resultDescription;

            switch (result)
            {
                case RefundResult.Ok:
                    resultDescription = TextConstants.Refund.RefundResult.Ok;
                    break;
                case RefundResult.OrderNotFound:
                    resultDescription = TextConstants.Refund.RefundResult.OrderNotFound;
                    break;
                case RefundResult.AlreadyDone:
                    resultDescription = TextConstants.Refund.RefundResult.AlreadyDone;
                    break;
                default:
                    resultDescription = TextConstants.Refund.RefundResult.Unknown;
                    break;
            }

            Console.WriteLine(TextConstants.Refund.Menu.OperationResultFormat, resultDescription);
        }
    }
}
