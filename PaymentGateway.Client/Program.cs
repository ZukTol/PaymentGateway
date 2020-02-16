using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Api.Services;
using PaymentGateway.Api.Services.Impl;
using PaymentGateway.Client.Services;
using PaymentGateway.Client.Services.Impl;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PaymentGateway.Client
{
    internal static class Program
    {
        private static IServiceProvider _serviceProvider;
        private static void Main(string[] args)
        {
            
            InitDependencyInjection();
            InitServerAddress();
            RunApp();

            Console.ReadKey();
        }

        private static void InitServerAddress()
        {
            var cfg = _serviceProvider.GetRequiredService<IConfiguration>();
            var serverPath = cfg.GetValue<string>(Constants.Cfg.ServerPath);
            var operationService = _serviceProvider.GetRequiredService<IOperationService>();
            operationService.InitServerPath(serverPath);
        }

        private static void InitDependencyInjection()
        {
            var config = GetConfiguration();

            var serviceCollection = new ServiceCollection()
                .AddScoped<IOperationService, OperationService>()
                .AddScoped<IPaymentMenuService, PaymentMenuService>()
                .AddSingleton(config);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }

        private static async void RunApp()
        {
            while (true)
            {
                PrintMenu();
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        GetCardInfo();
                        break;
                    case ConsoleKey.D2:
                        GetOperationInfo();
                        break;
                    case ConsoleKey.D3:
                        await Pay();
                        break;
                    case ConsoleKey.D4:
                        await GetStatus();
                        break;
                    case ConsoleKey.D5:
                        Refund();
                        break;
                    case ConsoleKey.D6:
                        return;
                }
                Console.WriteLine();
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1 - Список доступных карт");
            Console.WriteLine("2 - Список операций");
            Console.WriteLine("3 - Провести операцию (Pay)");
            Console.WriteLine("4 - Статус операции");
            Console.WriteLine("5 - Откатить операцию (Refund)");
            Console.WriteLine("6 - Выход");
        }

        private static void Refund()
        {
            throw new NotImplementedException();
        }

        private static async Task GetStatus()
        {

        }

        private static async Task Pay()
        {
            var operationService = _serviceProvider.GetRequiredService<IPaymentMenuService>();
            await operationService.RunMenu();
        }

        

        private static void GetCardInfo()
        {

        }

        private static void GetOperationInfo()
        {

        }
    }
}
