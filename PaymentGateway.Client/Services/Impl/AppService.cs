using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services.Impl
{
    internal class AppService : IAppService
    {
        private readonly IPaymentMenuService _paymentMenuService;
        private readonly IRefundMenuService _refundMenuService;
        private readonly IStatusMenuService _statusMenuService;

        public AppService(IPaymentMenuService paymentMenuService, IRefundMenuService refundMenuService, IStatusMenuService statusMenuService)
        {
            _paymentMenuService = paymentMenuService;
            _refundMenuService = refundMenuService;
            _statusMenuService = statusMenuService;
        }

        public async Task RunApp()
        {
            while (true)
            {
                PrintMenu();
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        GetCardInfo();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        GetOperationInfo();
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
                Console.WriteLine();
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

        }

        private void GetOperationInfo()
        {

        }
    }
}
