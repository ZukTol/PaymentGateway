using PaymentGateway.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services
{
    internal interface IStatusMenuService
    {
        Task RunMenu();
        string GetOperationStatus(OperationStatus result);
    }
}
