using PaymentGateway.Api.Entities;
using PaymentGateway.Api.Services;
using PaymentGateway.Client.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services.Impl
{
    internal class StatusMenuService : IStatusMenuService
    {
        private readonly IOperationService _operationService;

        public StatusMenuService(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public async Task RunMenu()
        {

            var orderId = ConsoleHelper.GetTextInput(TextConstants.Refund.Menu.EnterOrderId); ;

            var result = await _operationService.GetStatus(orderId);

            PrintOperationResult(result);
        }

        private void PrintOperationResult(OperationStatus result)
        {
            string resultDescription;
            resultDescription = GetOperationStatus(result);

            Console.WriteLine(TextConstants.Status.Menu.OperationResultFormat, resultDescription);
        }

        public string GetOperationStatus(OperationStatus result)
        {
            string resultDescription;
            switch (result)
            {
                case OperationStatus.Done:
                    resultDescription = TextConstants.Status.OperationStatus.Done;
                    break;
                case OperationStatus.NotFound:
                    resultDescription = TextConstants.Status.OperationStatus.NotFound;
                    break;
                case OperationStatus.Refund:
                    resultDescription = TextConstants.Status.OperationStatus.Refund;
                    break;
                default:
                    resultDescription = TextConstants.Status.OperationStatus.Unknown;
                    break;
            }

            return resultDescription;
        }
    }
}
