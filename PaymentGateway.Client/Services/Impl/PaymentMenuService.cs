using PaymentGateway.Api.Entities;
using PaymentGateway.Api.Services;
using PaymentGateway.Client.Utils;
using System;
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
            Console.WriteLine(TextConstants.Payment.Menu.EnterData);

            var orderId = ConsoleHelper.GetTextInput(TextConstants.Payment.Menu.EnterOrderId); ;
            var amountKop = GetAmountKop();
            var cardNumber = ConsoleHelper.GetTextInput(TextConstants.Payment.Menu.EnterCardNumber); ;
            var expiryMonth = ConsoleHelper.GetIntegerInput(TextConstants.Payment.Menu.EnterExpiryMonth);
            var expiryYear = ConsoleHelper.GetIntegerInput(TextConstants.Payment.Menu.EnterExpiryYear);
            var cvv = ConsoleHelper.GetIntegerInput(TextConstants.Payment.Menu.EnterCvv);



            var result = await _operationService.Pay(orderId, cardNumber, expiryMonth, expiryYear, cvv, amountKop);

            PrintOperationResult(result);
        }

        private void PrintOperationResult(PayResult result)
        {
            string resultDescription;

            switch (result)
            {
                case PayResult.Ok:
                    resultDescription = TextConstants.Payment.PayResult.Ok;
                    break;
                case PayResult.InvalidCardNumber:
                    resultDescription = TextConstants.Payment.PayResult.InvalidCardNumber;
                    break;
                case PayResult.OrderExists:
                    resultDescription = TextConstants.Payment.PayResult.OrderExists;
                    break;
                case PayResult.NotEnoughMoney:
                    resultDescription = TextConstants.Payment.PayResult.NotEnoughMoney;
                    break;
                case PayResult.InvalidCvv:
                    resultDescription = TextConstants.Payment.PayResult.InvalidCvv;
                    break;
                case PayResult.InvalidExpiryDate:
                    resultDescription = TextConstants.Payment.PayResult.InvalidExpiryDate;
                    break;
                case PayResult.OrderIdEmpty:
                    resultDescription = TextConstants.Payment.PayResult.OrderIdEmpty;
                    break;
                default:
                    resultDescription = TextConstants.Payment.PayResult.Unknown;
                    break;
            }
            Console.WriteLine(TextConstants.Payment.Menu.OperationResultFormat, resultDescription);
        }

        private long GetAmountKop()
        {
            var input = ConsoleHelper.GetTextInput(TextConstants.Payment.Menu.EnterAmount);
            return long.Parse(input, System.Globalization.NumberStyles.Integer);
        }
    }
}
