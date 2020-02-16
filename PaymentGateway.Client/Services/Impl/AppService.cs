using System;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services.Impl
{
    internal class AppService : IAppService
    {
        private readonly IPaymentMenuService _paymentMenuService;
        private readonly IRefundMenuService _refundMenuService;
        private readonly IStatusMenuService _statusMenuService;
        private readonly IOperationListService _operationListService;

        public AppService(IPaymentMenuService paymentMenuService, IRefundMenuService refundMenuService, IStatusMenuService statusMenuService, IOperationListService operationListService)
        {
            _paymentMenuService = paymentMenuService;
            _refundMenuService = refundMenuService;
            _statusMenuService = statusMenuService;
            _operationListService = operationListService;
        }

        public async Task RunApp()
        {
            while (true)
            {
                PrintMenu();
                var key = Console.ReadKey();
                Console.WriteLine();
                await ProcessUserInput(key.Key);
                Console.WriteLine();
            }
        }

        private async Task ProcessUserInput(ConsoleKey key)
        {
            try
            {
                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        GetCardInfo();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        await GetOperationInfo();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        await Pay();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        await GetStatus();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        await Refund();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        return;
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

        }

        private static void PrintMenu()
        {
            Console.WriteLine(TextConstants.MainMenu.P1);
            Console.WriteLine(TextConstants.MainMenu.P2);
            Console.WriteLine(TextConstants.MainMenu.P3);
            Console.WriteLine(TextConstants.MainMenu.P4);
            Console.WriteLine(TextConstants.MainMenu.P5);
            Console.WriteLine(TextConstants.MainMenu.P6);
        }

        private async Task Refund()
        {
            await _refundMenuService.RunMenu();
        }

        private async Task GetStatus()
        {
            await _statusMenuService.RunMenu();
        }

        private async Task Pay()
        {
            await _paymentMenuService.RunMenu();
        }

        private void GetCardInfo()
        {
            Console.WriteLine($"{Api.Constants.Card.Card1.Number} \t {Api.Constants.Card.Card1.ExpiryMonth}/{Api.Constants.Card.Card1.ExpireYear} \t {Api.Constants.Card.Card1.Cvv}");
            Console.WriteLine($"{Api.Constants.Card.Card2.Number} \t {Api.Constants.Card.Card2.ExpiryMonth}/{Api.Constants.Card.Card2.ExpireYear} \t {Api.Constants.Card.Card2.Cvv}");
        }

        private async Task GetOperationInfo()
        {
            await _operationListService.PrintOperationList();
        }
    }
}
