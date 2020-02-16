using PaymentGateway.Api.Entities;
using PaymentGateway.Api.Services;
using PaymentGateway.Client.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services.Impl
{
    internal class PaymentMenuService : IPaymentMenuService
    {
        private readonly IOperationService _operationService;

        public PaymentMenuService(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public async Task RunMenu()
        {
            Console.WriteLine("Введите данные операции, или нажмите Escape для отмены");

            var orderId = ConsoleHelper.GetTextInput("Введите номер заказа"); ;
            var amountKop = GetAmountKop();
            var cardNumber = ConsoleHelper.GetTextInput("Введите номер карты (16 цифр)"); ;
            var expiryMonth = ConsoleHelper.GetIntegerInput("Введите месяц окончания действия карты числом");
            var expiryYear = ConsoleHelper.GetIntegerInput("Введите год окончания действия карты числом (4 цифры)");
            var cvv = ConsoleHelper.GetIntegerInput("Введите проверочный код карты CVV (3 цифры)");

            var result = await _operationService.Pay(orderId, cardNumber, expiryMonth, expiryYear, cvv, amountKop);

            PrintOperationResult(result);
        }

        private void PrintOperationResult(PayResult result)
        {
            Console.WriteLine($"Результат операции: {result}");
        }

        private long GetAmountKop()
        {
            var input = ConsoleHelper.GetTextInput("Введите сумму заказа");
            return long.Parse(input, System.Globalization.NumberStyles.Integer);
        }
    }
}
