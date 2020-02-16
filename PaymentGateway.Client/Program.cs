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

            var appService = _serviceProvider.GetRequiredService<IAppService>();
            appService.RunApp().Wait();
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
                .AddSingleton<IOperationService, OperationService>()
                .AddScoped<IAppService, AppService>()
                .AddScoped<IPaymentMenuService, PaymentMenuService>()
                .AddScoped<IRefundMenuService, RefundMenuService>()
                .AddScoped<IStatusMenuService, StatusMenuService>()
                .AddScoped<IOperationListService, OperationListService>()
                .AddSingleton(config);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Constants.Cfg.SettingsFileName, true, true)
                .Build();
        }
    }
}
