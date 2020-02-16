using PaymentGateway.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services.Impl
{
    internal class OperationListService : IOperationListService
    {
        private readonly IOperationService _operationService;
        private readonly IStatusMenuService _statusMenuService;

        public OperationListService(IOperationService operationService, IStatusMenuService statusMenuService)
        {
            _operationService = operationService;
            _statusMenuService = statusMenuService;
        }

        public async Task PrintOperationList()
        {
            var list = await _operationService.GetOperationList();

            foreach (var item in list)
            {
                var status = _statusMenuService.GetOperationStatus(item.Status);
                Console.WriteLine($"Id: {item.OrderId}; \t Amount: {item.AmountKop}; \t Status: {status}; \t Card number: {item.CardNumber}");
            }
        }
    }
}
