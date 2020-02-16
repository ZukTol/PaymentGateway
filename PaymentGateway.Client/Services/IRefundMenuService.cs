using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services
{
    internal interface IRefundMenuService
    {
        Task RunMenu();
    }
}
